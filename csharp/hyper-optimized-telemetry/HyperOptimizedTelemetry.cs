using System;
using System.Linq;

public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        byte[] buffer = new byte[9];
        (var prefixByte, byte[] bytes) = reading switch
        {
            (>= short.MinValue and < short.MaxValue) and not 0 => 
                (254, BitConverter.GetBytes((ushort)reading)),
            (>= ushort.MinValue and <= ushort.MaxValue) => 
                (2, BitConverter.GetBytes((ushort)reading)),
            (>= int.MinValue and <= int.MaxValue) => 
                (252, BitConverter.GetBytes((int)reading)),
            (>= uint.MinValue and <= uint.MaxValue) => 
                (4, BitConverter.GetBytes((uint)reading)),
            _ => (248, BitConverter.GetBytes(reading))
        };
        
        buffer[0] = (byte) prefixByte;
        Buffer.BlockCopy(bytes, 0, buffer, 1, bytes.Length);
        return buffer;
    }
    public static long FromBuffer(byte[] buffer) =>
        buffer[0] switch
        {
            254 => BitConverter.ToInt16(buffer, 1),
            252 => BitConverter.ToInt32(buffer, 1),
            248 => BitConverter.ToInt64(buffer, 1),
            2 => BitConverter.ToUInt16(buffer, 1),
            4 => BitConverter.ToUInt32(buffer, 1),
            _ => 0,
        };
}
