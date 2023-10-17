using System.Text;

class NameFumbler {
    public string fumble(string name) {
      StringBuilder fumbledName = new StringBuilder();
      char[] charArray = name.ToCharArray();

      if(name.Contains("c")) {
        for(int i = 0; i < charArray.Length; i++){
          if(c=="c") {
            charArray[i] = "k";
          }
        }
      } else if(name.Contains("k")) {
        for(int i = 0; i < charArray.Length; i++){
          if(c=="k") {
            charArray[i] = "c";
          }
        }
      }

		  return fumbledName.ToString();
    }

    static void Main() {
    Console.WriteLine("Hello World");
  }
}