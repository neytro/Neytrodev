class Item {
  int? id;           // id w bazie (może być null przy tworzeniu nowego elementu)
  bool checked;
  String text;

  Item({this.id, required this.checked, required this.text});

  Map<String, dynamic> toMap() {
    return {
      'id': id,
      'checked': checked ? 1 : 0, // SQLite nie ma bool, używamy int
      'text': text,
    };
  }

  factory Item.fromMap(Map<String, dynamic> map) {
    return Item(
      id: map['id'],
      checked: map['checked'] == 1,
      text: map['text'],
    );
  }
}