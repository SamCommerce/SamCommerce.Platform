﻿using SamCommerce.Platform.Core.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SamCommerce.Platform.Core.Common
{
    public static class ReflectionUtility
    {
        private static readonly ObjectReferenceComparer _objectReferenceComparer = new ObjectReferenceComparer();

        public static IEnumerable<string> GetPropertyNames<T>(params Expression<Func<T, object>>[] propertyExpressions)
        {
            var retVal = new List<string>();
            foreach (var propertyExpression in propertyExpressions)
            {
                retVal.Add(GetPropertyName(propertyExpression));
            }
            return retVal;
        }

        public static string GetPropertyName<T>(Expression<Func<T, object>> propertyExpression)
        {
            string retVal = null;
            if (propertyExpression != null)
            {
                var lambda = (LambdaExpression)propertyExpression;
                MemberExpression memberExpression;
                if (lambda.Body is UnaryExpression unaryExpression)
                {
                    memberExpression = (MemberExpression)unaryExpression.Operand;
                }
                else
                {
                    memberExpression = (MemberExpression)lambda.Body;
                }
                retVal = memberExpression.Member.Name;

            }
            return retVal;
        }

        /// <summary>
        /// Search all type properties (ancestors properties included) that have specific attribute
        /// </summary>
        /// <param name="type">The type which properties need to be sought</param>
        /// <param name="attribute">The attribute to search</param>
        /// <returns></returns>
        public static PropertyInfo[] FindPropertiesWithAttribute(this Type type, Type attribute)
        {
            return FindPropertiesWithAttribute(type, attribute, true);
        }

        /// <summary>
        /// Search all type properties that have specific attribute
        /// </summary>
        /// <param name="type">The type which properties need to be sought</param>
        /// <param name="attribute">The attribute to search</param>
        /// <param name="inherit">Should search or not thru type ancestors properties</param>
        /// <returns></returns>
        public static PropertyInfo[] FindPropertiesWithAttribute(this Type type, Type attribute, bool inherit)
        {
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            return properties.Where(x => x.GetCustomAttributes(attribute, inherit).Any()).ToArray();
        }

        public static bool IsHaveAttribute(this PropertyInfo propertyInfo, Type attribute)
        {
            return propertyInfo.GetCustomAttributes(attribute, true).Any();
        }


        public static Type[] GetTypeInheritanceChain(this Type type)
        {
            var retVal = new List<Type>();

            retVal.Add(type);
            var baseType = type.BaseType;
            while (baseType != typeof(Entity) && baseType != typeof(object))
            {
                retVal.Add(baseType);
                baseType = baseType.BaseType;
            }
            return retVal.ToArray();
        }

        public static Type[] GetTypeInheritanceChainTo(this Type type, Type toBaseType)
        {
            var retVal = new List<Type>();

            retVal.Add(type);
            var baseType = type.BaseType;
            while (baseType != toBaseType && baseType != typeof(object))
            {
                retVal.Add(baseType);
                baseType = baseType.BaseType;
            }
            return retVal.ToArray();
        }

        public static bool IsDerivativeOf(this Type type, Type typeToCompare)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            var retVal = type.BaseType != null;
            if (retVal)
            {
                retVal = type.BaseType == typeToCompare;
            }
            if (!retVal && type.BaseType != null)
            {
                retVal = type.BaseType.IsDerivativeOf(typeToCompare);
            }
            return retVal;
        }

        public static T[] GetFlatObjectsListWithInterface<T>(this object obj, List<T> resultList = null)
        {
            resultList ??= new List<T>();
            var allObjects = new HashSet<object>(_objectReferenceComparer);
            obj.GetFlatObjectsListWithInterface(resultList, allObjects);

            return resultList.ToArray();
        }

        private static void GetFlatObjectsListWithInterface<T>(this object obj, List<T> resultList, HashSet<object> allObjects)
        {
            // Prevent loops
            if (!allObjects.Add(obj))
            {
                return;
            }

            if (obj is T t)
            {
                resultList.Add(t);
            }

            var properties = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            {
                // Handle single objects
                if (typeof(T).IsAssignableFrom(property.PropertyType))
                {
                    var value = property.GetValue(obj);
                    value?.GetFlatObjectsListWithInterface(resultList, allObjects);
                }
                else if (property.GetIndexParameters().Length == 0)
                {
                    var value = property.GetValue(obj);

                    // Handle collections and arrays
                    if (!(value is string) && value is IEnumerable enumerable)
                    {
                        foreach (var collectionObject in enumerable)
                        {
                            if (collectionObject is T)
                            {
                                collectionObject.GetFlatObjectsListWithInterface(resultList, allObjects);
                            }
                        }
                    }
                }
            }
        }

        public static bool IsDictionary(this Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            var retVal = typeof(IDictionary).IsAssignableFrom(type);
            if (!retVal)
            {
                retVal = type.IsGenericType && typeof(IDictionary<,>).IsAssignableFrom(type.GetGenericTypeDefinition());
            }
            return retVal;
        }

        public static bool IsAssignableFromGenericList(this Type type)
        {
            foreach (var intType in type.GetInterfaces())
            {
                if (intType.IsGenericType
                    && intType.GetGenericTypeDefinition() == typeof(IList<>))
                {
                    return true;
                }
            }
            return false;
        }


        private class ObjectReferenceComparer : IEqualityComparer<object>
        {
            public new bool Equals(object x, object y)
            {
                return ReferenceEquals(x, y);
            }

            public int GetHashCode(object obj)
            {
                if (obj == null)
                {
                    throw new ArgumentNullException(nameof(obj));
                }

                return obj.GetHashCode();
            }
        }
    }
}