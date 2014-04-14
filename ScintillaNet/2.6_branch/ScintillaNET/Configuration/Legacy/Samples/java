import java.util.*;

public class PhoneList {
   public static void main(String args[]) {
     // Create map - maintain insertion order
     Map map = new LinkedHashMap();

     // Add members
     map.put("George", "202-456-1111");
     map.put("Bill", "212-348-8882");
     map.put("Hillary", "202-224-4451");
     map.put("Elvis", "901-332-3322");
     map.put("Jimmy", "229-924-6935");

     // Print map
     print(map, "Insertion Order:");

     // Convert map to regular
     map = new HashMap(map);

     // Print map
     print(map, "Hashing Order:");

     // Convert map to sorted
     map = new TreeMap(map);

     // Print map
     print(map, "Sorted");
   }

   private static void print(Map map, String message) {
     System.out.println(message);
     Set entries = map.entrySet();
     Iterator iterator = entries.iterator();
     while (iterator.hasNext()) {
       Map.Entry entry = (Map.Entry)iterator.next();
       System.out.println(entry.getKey() + " : "
         + entry.getValue());
     }
     System.out.println();
   }
}
