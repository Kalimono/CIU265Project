using System.Text;

public string Fumble(string name) {
  StringBuilder fumbledName = new StringBuilder();
  name = name.ToLower();

  for (int i = 0; i < name.Length; i++) {
    char c = name[i];

    if (c == 'c') {
      fumbledName.Append('k');
      if(i+1 < name.Length) {
        if(name[i+1] == 'h') {
          i++
        }
      }
    }
    else if (c == 'k') {
      fumbledName.Append('c');
    }
    else if (i+1 < name.Length) {
      if (c == 'f' && name[i+1] != 'f') {
        fumbledName.Append("ph");
      }
    }
    else if (i+1 < name.Length) {
      if (c == 'p' && name[i+1] == 'h') {
        fumbledName.Append("f");
        i++;
      }
    }
    else if (i+1 < name.Length) {
      if (name[i+1] == c) {
        fumbledName.Append(c);
        i++;
      }
    }
    else {
      fumbledName.Append(c);
    }
  }

  fumbledResult = char.ToUpper(fumbledResult[0]) + fumbledResult.Substring(1);
  return fumbledResult;
}