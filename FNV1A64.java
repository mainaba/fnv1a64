import java.math.BigInteger;

/**
 * Computes the FNV1A64 hash for the input string.
 */
public final class FNV1A64 {
    private final static int _radix = 16;
    private final static BigInteger _basis = new BigInteger("CBF29CE484222325", _radix);
    private final static BigInteger _modulus = new BigInteger("10000000000000000", _radix);
    private final static BigInteger _prime = new BigInteger("00000100000001B3", _radix);

    /***
     * Generates a hash value.
     * 
     * @param s the input string
     * @return the message digest
     */
    public static String hash(String s) {
        BigInteger hash = _basis;
        for (final byte b : s.getBytes()) {
            hash = hash.xor(BigInteger.valueOf(b)).multiply(_prime).mod(_modulus);
        }
        return hash.toString(_radix);
    }
}
