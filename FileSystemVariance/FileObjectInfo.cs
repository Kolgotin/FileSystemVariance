using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemVarianceLib
{
    class FileObjectInfo : AbstractObjectInfo
    {
        public string Name
        {
            get => _Name;
            private set
            {
                _Name = value;
            }
        }

        public FileObjectInfo(string fullPath)
        {
            _FullPath = fullPath;
            var fileInfo = new FileInfo(_FullPath);

            _Name = fileInfo.Name;
            _CreatedDate = fileInfo.CreationTime;
            _LastChangedDate = fileInfo.LastWriteTime;
            _ByteSize = fileInfo.Length;

        }

    public override DateTime GetCreatedDate()
        {
            return _CreatedDate;
        }

        public override DateTime GetLastChangedDate()
        {
            return _LastChangedDate;
        }

        public override long GetByteSize()
        {
            return _ByteSize;
        }
    }
}
