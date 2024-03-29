﻿using ConnectedDevelopment.InformSystem.WebApi.Client.Arguments;
using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Validators
{
    /// <summary>
    /// Validator class
    /// </summary>
    /// <typeparam name="T">The type of object to validate</typeparam>
    public class Validator<T> : IValidator<T>
        where T : class
    {
        private const int MaxDepth = 30;

        private readonly IValidator _validator;

        /// <summary>
        /// Initializes a new instance of the <see cref="Validator"/> class.
        /// </summary>
        public Validator(
            IValidator validator)
        {
            Argument.NotNull(validator, nameof(validator));

            _validator = validator;
        }

        /// <summary>
        /// Validate object
        /// </summary>
        /// <param name="instance">The instance to validate</param>
        public void ValidateObject(T instance)
        {
            Argument.NotNull(instance, nameof(instance));

            ValidateObjectRecursive(instance, 0, MaxDepth);
        }

        private void ValidateObjectRecursive(object instance, int depth, int maxDepth)
        {
            if (depth >= maxDepth)
            {
                throw new ArgumentException("Validation exceeding maximum allowed depth " + maxDepth, nameof(instance));
            }

            if (instance is string)
            {
                return;
            }

            var nextDepth = depth + 1;

            if (instance is IEnumerable instances)
            {
                ValidateCollection(instances, nextDepth, maxDepth);
            }
            else
            {
                ValidateInstance(instance);

                ValidateProperties(instance, nextDepth, MaxDepth);
            }
        }

        private void ValidateInstance(object instance)
        {
            var context = new ValidationContext(instance, null, null);

            // Throws an exception when instance is invalid.
            _validator.ValidateObject(instance, context, validateAllProperties: true);
        }

        private void ValidateCollection(IEnumerable collection, int nextDepth, int maxDepth)
        {
            foreach (var item in collection)
            {
                if (item != null)
                {
                    ValidateObjectRecursive(item, nextDepth, maxDepth);
                }
            }
        }

        private void ValidateProperties(object instance, int nextDepth, int maxDepth)
        {
            var type = instance.GetType();

            if (type.IsClass == false)
            {
                return;
            }

            var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(x => x.CanRead == true)
                .Where(x => x.PropertyType.IsClass == true || x.PropertyType.IsInterface == true)
                .Where(x => x.PropertyType != typeof(string))
                .Where(x => x.PropertyType != typeof(Uri))
                .Where(x => x.PropertyType.IsPrimitive == false)
                .Where(x => x.PropertyType.IsEnum == false)
                .Where(x => x.PropertyType.IsValueType == false)
                .Where(x => typeof(Task).IsAssignableFrom(x.PropertyType) == false)
                .ToList();

            foreach (var property in properties)
            {
                var value = property.GetValue(instance);

                if (value == null)
                {
                    continue;
                }

                ValidatePropertyValue(value, nextDepth, maxDepth);
            }
        }

        private void ValidatePropertyValue(object instance, int nextDepth, int maxDepth)
        {
            if (instance is IEnumerable collection)
            {
                foreach (var item in collection)
                {
                    if (item != null)
                    {
                        ValidateObjectRecursive(item, nextDepth, maxDepth);
                    }
                }
            }

            else
            {
                ValidateObjectRecursive(instance, nextDepth, maxDepth);
            }
        }
    }
}
