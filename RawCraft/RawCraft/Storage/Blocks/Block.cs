using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Storage
{
    class Block
    {
        private bool Transparent, Multitex, Metadata, Entity;

        public Block()
        {
            Transparent = false;
            Multitex = false;
            Metadata = false;
        }

        public bool IsTransparent
        {
            get { return Transparent; }
            set { Transparent = value; }
        }

        public bool IsMultitex
        {
            get { return Multitex; }
            set { Multitex = value; }
        }

        public bool HasMetadata
        {
            get { return Metadata; }
            set { Metadata = value; }
        }

        public bool IsEntity
        {
            get { return Entity; }
            set { Entity = value; }
        }
    }
}
