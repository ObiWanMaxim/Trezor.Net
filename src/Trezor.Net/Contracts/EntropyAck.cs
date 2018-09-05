﻿using ProtoBuf;

namespace Trezor.Net.Contracts
{
    [ProtoContract]
    public class EntropyAck
    {
        [ProtoMember(1, Name = @"entropy")]
        public byte[] Entropy { get; set; }

        public bool ShouldSerializeEntropy() => Entropy != null;
        public void ResetEntropy() => Entropy = null;
    }
}