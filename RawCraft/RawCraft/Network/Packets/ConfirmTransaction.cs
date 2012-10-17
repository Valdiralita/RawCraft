using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class ConfirmTransaction
    {
        public ConfirmTransaction(Stream aesStream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Confirm Transaction (0x6A)"); 
            Reader.ReadUnsignedByte(aesStream);
            Reader.ReadSignedShort(aesStream);
            Reader.ReadUnsignedByte(aesStream);
        }
    }
}
