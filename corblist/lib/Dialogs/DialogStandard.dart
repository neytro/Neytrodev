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
}
