/*
Copyright (c) 2013, Dienst Wegverkeer, RDW, All rights reserved. 

Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met: 

• Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer. 
• Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution. 
• Neither the name of the Dienst Wegverkeer, RDW,  nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission. 

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

*/

namespace EVR.Reader
{
    using EVR.TLVParser;

    public class EFSignature : ElementaryFile
    {
        public TLV Signature
        {
            get;
            private set;
        }

        public override System.Text.Encoding CharacterSetEncoding
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        /*
         * Private constructor; use factory objects below
         */
        private EFSignature(byte[] AID, CardReader cardReader, byte[] FileID)
            : base(AID, cardReader, FileID)
        {
            Signature = this.GetTag("1,30|1,03");
        }

        /*
         * Create a Signature object for the Registration A
         */
        public static EFSignature Create_Signature_A(byte[] AID, CardReader cardReader)
        {
            return new EFSignature(AID, cardReader, new byte[] { 0xE0, 0x01 });
        }

        /*
         * Create a Signature object for the Registration B
         */
        public static EFSignature Create_Signature_B(byte[] AID, CardReader cardReader)
        {
            return new EFSignature(AID, cardReader, new byte[] { 0xE0, 0x11 });
        }
    }
}
