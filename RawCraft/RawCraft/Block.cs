using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MC_XNA
{
    class Block
    {
        byte _BlockType, _BlockMetadata, _Blocklight, _Skylight;

        public byte BlockType
        {
            get { return _BlockType; }
            set { _BlockType = value; }
        }

        public byte BlockMetadata
        {
            get { return _BlockMetadata; }
            set { _BlockMetadata = value; }
        }

        public byte Blocklight
        {
            get { return _Blocklight; }
            set { _Blocklight = value; }
        }

        public byte Skylight
        {
            get { return _Skylight; }
            set { _Skylight = value; }
        }
    }
}
