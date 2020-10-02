﻿using System;

namespace FileSystemVarianceLib
{
    abstract class AbstractObjectInfo : ICreatedDateReturnable, ILastChangedDateReturnable, IByteSizeReturnable
    {
        protected string _Name;
        protected DateTime _CreatedDate;
        protected DateTime _LastChangedDate;
        protected long _ByteSize;

        public abstract DateTime GetCreatedDate();
        public abstract DateTime GetLastChangedDate(); 
        public abstract long GetByteSize();
    }
}
