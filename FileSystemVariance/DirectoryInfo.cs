using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemVarianceLib
{
    class DirectoryInfo : AbstractObjectInfo
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

        public DirectoryInfo(string fullPath)
        {
            _FullPath = fullPath;
            var fileInfo = new FileInfo(_FullPath);

            _Name = fileInfo.Name;
            _CreatedDate = fileInfo.CreationTime;

            _Contain = FindContainObjects(_FullPath);
        }

        private List<AbstractObjectInfo> FindContainObjects(string path)
        {
            List<AbstractObjectInfo> res = new List<AbstractObjectInfo>();

            var files = Directory.GetFiles(path).Select(file => new FileObjectInfo(file));
            res.AddRange(files);

            var dirs = Directory.GetDirectories(path).Select(dir => new DirectoryInfo(dir));
            res.AddRange(dirs);

            return res;
        }

        public override DateTime GetCreatedDate()
        {
            return _CreatedDate;
        }

        public override DateTime GetLastChangedDate()
        {
            if (!_LastChangedDateCalculated)
            {
                if(_Contain.Count == 0)
                {
                    _LastChangedDate = _CreatedDate;
                }
                else
                {
                    _LastChangedDate = _Contain.Max(x => x.GetLastChangedDate());
                }
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
