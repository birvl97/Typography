﻿//MIT, 2015-2016, Michael Popoloski, WinterDev

using System.IO;
namespace Typography.OpenFont.Tables
{

    class CvtTable : TableEntry
    {
        public override string Name => "cvt "; //need 4 chars//***
        //

        /// <summary>
        /// control value in font unit
        /// </summary>
        internal int[] _controlValues;
        protected override void ReadContentFrom(BinaryReader reader)
        {
            int nelems = (int)(this.TableLength / sizeof(short));
            var results = new int[nelems];
            for (int i = 0; i < nelems; i++)
            {
                results[i] = reader.ReadInt16();
            }
            this._controlValues = results;
        }
    }
    class PrepTable : TableEntry
    {

        public override string Name => "prep";
        //

        internal byte[] _programBuffer;
        //
        protected override void ReadContentFrom(BinaryReader reader)
        {
            _programBuffer = reader.ReadBytes((int)this.TableLength);
        }
    }
    class FpgmTable : TableEntry
    {
        public override string Name => "fpgm";
        //

        internal byte[] _programBuffer; 
        protected override void ReadContentFrom(BinaryReader reader)
        {
            _programBuffer = reader.ReadBytes((int)this.TableLength);
        }
    }
}