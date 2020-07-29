using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class BaseEntity
    {
        public int Id { get; set; }

        private int? _hashCode;

        public override int GetHashCode()
        {
            if (_hashCode.HasValue)
                return _hashCode.Value;

            _hashCode = HashCode.Combine(GetType(), Id);

            return _hashCode.Value;
        }

    }
}
