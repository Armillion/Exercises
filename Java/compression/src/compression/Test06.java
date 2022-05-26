package compression;

import java.util.ArrayList;
import java.util.Collections;
import java.util.LinkedList;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;
import java.util.stream.Collectors;

public class Test06 {
  // imputs words separated with spaces
  public static void inputSequence(String sequence, Compression comp) {
    for (var word : sequence.split(" "))
    {
    	comp.addWord(word);
    }
  }

  // joins output words into single string
  public static String outputSequence(Compression comp, int size) {
    List<String> ls = new LinkedList<String>();
    for (int i = 0; i < size; i++) {
      ls.add(comp.getWord());
    }
    return String.join(" ", ls);
  }

  // uses header to decompress compressed sequence
  public static <K> String decompressSequence(Map<String, String> header, String sequence) {
    List<String> seq = new ArrayList<String>(List.of(sequence.split(" ")));
    System.out.println(seq);
    List<String> arr = new ArrayList<String>();
    for (String a : seq) {
      if(a.charAt(0) == '0')
      {
    	  String decompr = null;
    	  for (Entry<String, String> entry : header.entrySet()) {
    	        if (entry.getValue().equals(a)) {
    	            decompr = entry.getKey();
    	        }
    	  }
    	  arr.add(decompr);
      }
      else
      {
    	  String decompr = a.replaceFirst("1","");
    	  System.out.println(a);
    	  arr.add(decompr);
      }
    }
    System.out.println(String.join(" ", arr));
    //arr = arr.stream().map(el -> el.substring(1)).collect(Collectors.toList());
    return String.join(" ", arr);
  }

  // calculates header bit length
  public static int getHeaderLength(Map<String, String> header) {
    var entry1 = header.entrySet().iterator().next();
    return (entry1.getKey().length() + entry1.getValue().length()) * header.size();
  }

  // calculates sequence length
  public static int getSequenceLenght(String sequence) {
    return List.of(sequence.split(" ")).stream().mapToInt(String::length).sum();
  }

  public static void main(String[] args) {

    // test 01 - oramus przyklad 1
    var comp = new Compression();
    String inpSequence = "001 001 001 010 111 011 001 001 110 000 001 001 001 001";
    inputSequence(inpSequence, comp);
    comp.compress();
    String outSequence = outputSequence(comp, inpSequence.split(" ").length);
    System.out.println(outSequence);
    Map<String, String> header = comp.getHeader();
    System.out.println(outSequence);
    System.out.println(("0 0 0 1010 1111 1011 0 0 1110 1000 0 0 0 0".equals(outSequence) ? "passed" : "failed") + " test 01 - oramus1");
    // test 02 - oramus przyklad 2 - decompression
  
    comp = new Compression();
    inpSequence = "000 001 000 001 000 001 000 001 011 001 000 110 001 000 111 001 001 000 000 000 001";
    inputSequence(inpSequence, comp);
    comp.compress();
    outSequence = outputSequence(comp, inpSequence.split(" ").length);
    header = comp.getHeader();
    System.out.println((inpSequence.equals(decompressSequence(header, outSequence)) ? "passed" : "failed") + " test 02 - oramus2 - decompression");

    // test 03 - oramus przyklad 2 - optimal compression
    int resLength = getSequenceLenght(outSequence) + getHeaderLength(header);
    int expLength = getSequenceLenght("00 01 00 01 00 01 00 01 1011 01 00 1110 01 00 1111 01 01 00 00 00 01") + 10;

    if (resLength != expLength)
      System.out.println("failed test 03 - oramus2 - optimal compression | resultLength:" + resLength + ", optimal:" + expLength);
    else
      System.out.println("passed test 03 - oramus2 - optimal compression ");

    // test 04 - impossible compression
    comp = new Compression();
    inpSequence = "00 01 10 11";
    inputSequence(inpSequence, comp);
    comp.compress();
    header = comp.getHeader();
    System.out.println((header.size() == 0 ? "passed" : "failed") + " test 04 - impossible compression");

    // test 05 - random test 1 - decompression
    comp = new Compression();
    inpSequence = "0101 0101 0101 0101 0101 0101 0101 0101 0101 0101 0011 0011 0011 0011 0011 0011 0011 0011 0011 0011 0001 0001 0001 0001 0001 0001 0001 0001 0001 0001 0111 1000 0100 0111 0001 1000 1000 1001 0101 1000 1001 1001 0000 0010 0000 0101 0101 0100 0011 0100";
    inputSequence(inpSequence, comp);
    comp.compress();
    header = comp.getHeader();
    outSequence = outputSequence(comp, inpSequence.split(" ").length);
    System.out.println(outSequence);
    System.out.println((inpSequence.equals(decompressSequence(header, outSequence)) ? "passed" : "failed") + " test 05 - random test 1 - decompression");

    // test 06 - oramus przyklad 2 - optimal compression
    resLength = getSequenceLenght(outSequence) + getHeaderLength(header);
    expLength = getSequenceLenght(
        "00 00 00 00 00 00 00 00 00 00 01 01 01 01 01 01 01 01 01 01 10001 10001 10001 10001 10001 10001 10001 10001 10001 10001 10111 11000 10100 10111 10001 11000 11000 11001 00 11000 11001 11001 10000 10010 10000 00 00 10100 01 10100")
        + 12;
    System.out.println(outSequence);
    if (resLength != expLength)
      System.out.println("failed test 06 - random test 1 - optimal compression | resultLength:" + resLength + ", optimal:" + expLength);
    else
      System.out.println("passed test 06 - random test 1 - optimal compression ");
  }
}
