using System;
using System.Collections.Generic;

namespace DependenyInjector
{
    /// <summary>
    /// DependencyInjector is designed to control what should be returned when object creation is requested.
    /// In most situation it creates and returns new object of class given as second template argument of Get
    /// We can override this behavior in two ways: 
    ///  - by setting type returned for requested interface - new object of this type will be created every time
    ///  - by setting exact object 
    /// For working simple example see unit test for this class
    /// </summary>
    public static class DependencyInjector
    {
        /// <summary>
        /// Helper class to check if given pair of types can match and eventually put them in dictionary
        /// </summary>
        public class ResolvableType
        {
            private Type InType { get; set; }
            /// <summary>
            /// By template parameter developer points which type(interface) should be covered
            /// </summary>
            /// <typeparam name="T">Type we want to override</typeparam>
            public void As<T>()
            {
                Type asType = typeof(T);
                if (asType.IsAssignableFrom(this.InType))
                {
                    objects.Remove(asType);
                    types[asType] = InType;
                }
                else
                    throw new BadTypeException("Bad type");
            }

            /// <summary>
            /// Simple constructor - takes Type of objects to be returned
            /// </summary>
            /// <param name="i"></param>
            public ResolvableType(Type i)
            {
                InType = i;
            }
        }
        /// <summary>
        /// Helper class to check if given pair: object-type can match and eventually put them in dictionary
        /// </summary>
        public class ResolvableObject
        {
            private Object InObject;

            /// <summary>
            /// By template parameter developer points which type(interface) should be covered
            /// </summary>
            /// <typeparam name="T">Type we want to override</typeparam>
            public void As<T>()
            {
                
                Type asType = typeof(T);
                if (asType.IsAssignableFrom(InObject.GetType()))
                {
                    types.Remove(asType);
                    objects[asType] = InObject;
                }
                else
                    throw new BadTypeException("Bad type");
            }
            /// <summary>
            /// Simple constructor - takes Object to be returned
            /// </summary>
            /// <param name="o">Object to be returned</param>
            public ResolvableObject(Object o)
            {
                InObject = o;
            }
        }

        private static readonly Dictionary<Type, Type> types = new Dictionary<Type, Type>();
        private static readonly Dictionary<Type, Object> objects = new Dictionary<Type, Object>();

        /// <summary>
        /// Method used to create new Type-Type mapping. Note that As() must be called on returned object
        /// if not - nothing will happen
        /// </summary>
        /// <typeparam name="T">Type to be registered</typeparam>
        /// <returns>ResolvableType</returns>
        public static ResolvableType Register<T>()
        {
            return new ResolvableType(typeof(T));
        }
        /// <summary>
        /// Method used to get object. First it will check for T in 
        /// object/type mapping dictionaries and return what was found. If no mapping is set it will return new object of type U. 
        /// Note that T-U must be related. Example T t = new U() must be correct cast.
        /// </summary>
        /// <typeparam name="T">Type we want (general, interface)</typeparam>
        /// <typeparam name="U">More specified - exact type we need</typeparam>
        /// <returns>Object of type T</returns>
        public static T Get<T, U>()
        {
            Type t = typeof(T);
            if(types.ContainsKey(t))
                return (T)Activator.CreateInstance(types[t]);
            if(objects.ContainsKey(t))
                return (T)objects[t];
            return (T)Activator.CreateInstance(typeof(U));
        }

        public static T Get<T, U>(params object[] paramArray)
        {
            Type t = typeof(T);
            if (types.ContainsKey(t))
                return (T)Activator.CreateInstance(types[t], args: paramArray);
            if (objects.ContainsKey(t))
                return (T)objects[t];
            return (T)Activator.CreateInstance(typeof(U), args: paramArray);
        }
        /// <summary>
        /// Method used to create new Type-Object mapping. Note that As() must be called on returned object
        /// if not - nothing will happen
        /// </summary>
        /// <param name="o">Object to be returned when Get() called for proper type</param>
        /// <returns></returns>
        public static ResolvableObject Register(Object o)
        {
            return new ResolvableObject(o);
        }
        
        public static void Clear()
        {
            types.Clear();
            objects.Clear();
        }
    }
}
