using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemVarianceLib
{
    class DirectoryInfo : AbstractObjectInfo, ICreatedDateReturnable
    {
        private bool _LastChangedDateCalculated;
        private bool _ByteSizeCalculated;

        private List<AbstractObjectInfo> _Contain;
        public List<AbstractObjectInfo> Contain
        {
            get => _Contain;
            private set
            {
                _Contain = value;
            }
        }

        public string Name
        {
            get => _Name;
            private set
            {
                _Name = value;
            }
        }
        public long ByteSize
        {
            get => _ByteSize;
            private set
            {
                _ByteSize = value;
            }
        }

        public override DateTime GetCreatedDate()
        {
            return _CreatedDate;
        }

        public override DateTime GetLastChangedDate()
        {
            if (!_LastChangedDateCalculated)
            {
                _LastChangedDate = _Contain.Max(x => x.GetLastChangedDate());
                _LastChangedDateCalculated = true;
            }
            return _LastChangedDate;
        }

        public override long GetByteSize()
        {
            if (!_ByteSizeCalculated)
            {
                _ByteSize = _Contain.Sum(x => x.GetByteSize());
                _ByteSizeCalculated = true;
            }
            return _ByteSize;
        }
    }
}
