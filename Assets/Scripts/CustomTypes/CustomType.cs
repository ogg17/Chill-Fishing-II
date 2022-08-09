using System.Collections.Generic;

namespace CustomTypes
{
    public class CustomType<T>
    {
        protected T Value;

        protected CustomType(T value)
        {
            Value = value;
        }
        
        protected CustomType(){}

        public static implicit operator CustomType<T>(T a)
        {
            return new CustomType<T>(a);
        }

        public static implicit operator T(CustomType<T> a)
        {
            return a.Value;
        }
        
        public static bool operator <(CustomType<T> a, CustomType<T> b)
        {
            return a < b;
        }

        public static bool operator >(CustomType<T> a, CustomType<T> b)
        {
            return a > b;
        }

        public static bool operator <=(CustomType<T> a, CustomType<T> b)
        {
            return a <= b;
        }

        public static bool operator >=(CustomType<T> a, CustomType<T> b)
        {
            return a >= b;
        }

        public static bool operator ==(CustomType<T> a, CustomType<T> b)
        {
            return a == b;
        }

        public static bool operator !=(CustomType<T> a, CustomType<T> b)
        {
            return a != b;
        }

        private bool Equals(CustomType<T> other)
        {            
            return EqualityComparer<T>.Default.Equals(Value, other.Value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CustomType<T>)obj);
        }
        
        public override int GetHashCode()
        {
            return EqualityComparer<T>.Default.GetHashCode(Value);
        }
    }
}