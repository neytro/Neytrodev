import 'package:corblist/Repository/Item.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

class Dialogs {
  static void showInputDialogStandard(
    BuildContext context,
    String hintText,
    String ok,
    String cancel,
    Future<void> Function(String text) callback,
  ) {
    final TextEditingController _textController = TextEditingController();

    showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          content: TextField(
            controller: _textController,
            decoration: InputDecoration(hintText: hintText),
          ),
          actions: <Widget>[
            TextButton(
              child: Text(cancel),
              onPressed: () {
                Navigator.of(context).pop();
              },
            ),
            ElevatedButton(
              child: Text(ok),
              onPressed: () {
                String query = _textController.text;
                callback(query);
              },
            ),
          ],
        );
      },
    );
  }

  static void showInputDialogImageAndName(
    BuildContext context,
    String hintText,
    String ok,
    String cancel,
    Future<void> Function(Item item) callback,
  ) {
    final TextEditingController _textController = TextEditingController();

    showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          content: Row(

            children: [
              Expanded(
                child: TextField(
                  controller: _textController,
                  decoration: InputDecoration(hintText: hintText),
                ),
              ),
              SizedBox(width: 10),
              IconButton(icon: Icon(Icons.camera_alt),padding: EdgeInsets.zero, onPressed: () async {}),
              SizedBox(width: 5),
              IconButton(icon: Icon(Icons.photo_library),padding: EdgeInsets.zero, onPressed: () async {},),
            ],

            //TextField(
            //controller: _textController,
            //decoration: InputDecoration(hintText: hintText),
          ),

          actions: <Widget>[
            TextButton(
              child: Text(cancel),
              onPressed: () {
                Navigator.of(context).pop();
              },
            ),
            ElevatedButton(
              child: Text(ok),
              onPressed: () {
                String query = _textController.text;
                Item item = Item(checked: false, text: _textController.text);
                callback(item);
                Navigator.of(context).pop();
              },
            ),
          ],
        );
      },
    );
  }
}
