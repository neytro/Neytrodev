class Item {
  int? id;
  bool checked;
  String text;

  Item({this.id, required this.checked, required this.text});

  Map<String, dynamic> toMap() {
    return {
      'id': id,
      'checked': checked ? 1 : 0,
      'text': text,
    };
  }

  static Item fromMap(Map<String, dynamic> map) {
    return Item(
      id: map['id'],
      checked: map['checked'] == 1,
      text: map['text'],
    );
  }
}