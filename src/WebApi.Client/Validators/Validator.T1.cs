using Informapp.InformSystem.WebApi.Client.Arguments;
using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Informapp.InformSystem.WebApi.Client.Validators
{
    /// <summary>
    /// Validator class
    /// </summary>
    /// <typeparam name="T">The type of object to validate</typeparam>
    public class Validator<T> : IValidator<T>
        where T : class
    {
        private const int MaxDepth = 30;

        /// <summary>
        /// Initializes a new instance of the <see cref="Validator"/> class.
        /// </summary>
        public Validator()
        {

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

            var instances = (instance as IEnumerable);

            if (instances != null)
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
            Validator.ValidateObject(instance, context, true);
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
                .Where(x => x.CanRead)
                .Where(x => x.PropertyType.IsClass == true)
                .Where(x => x.PropertyType != typeof(string))
                .Where(x => x.PropertyType != typeof(Uri))
                .Where(x => x.PropertyType.IsPrimitive == false)
                .Where(x => x.PropertyType.IsEnum == false)
                .Where(x => x.PropertyType.IsValueType == false)
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

        private void ValidateFields(object instance, int nextDepth, int maxDepth)
        {
            var type = instance.GetType();

            if (type.IsClass == false)
            {
                return;
            }

            var fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public)
                .Where(x => x.FieldType.IsClass == true)
                .Where(x => x.FieldType != typeof(string))
                .Where(x => x.FieldType != typeof(Uri))
                .Where(x => x.FieldType.IsPrimitive == false)
                .Where(x => x.FieldType.IsEnum == false)
                .Where(x => x.FieldType.IsValueType == false)
                .ToList();

            foreach (var field in fields)
            {
                var value = field.GetValue(instance);

                if (value == null)
                {
                    continue;
                }

                ValidatePropertyValue(value, nextDepth, maxDepth);
            }
        }

        private void ValidatePropertyValue(object instance, int nextDepth, int maxDepth)
        {
            var collection = (instance as IEnumerable);

            if (collection != null)
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
