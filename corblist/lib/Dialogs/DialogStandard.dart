import 'package:corblist/Repository/Item.dart';
import 'package:corblist/l10n/app_localizations.dart';
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
    String titleAddItem,
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
          title: Text(titleAddItem),
          content: Row(
            children: [
              Expanded(
                child: TextField(
                  controller: _textController,
                  decoration: InputDecoration(hintText: hintText),
                ),
              ),
              SizedBox(width: 10),
              PopupMenuButton<String>(
                onSelected: (value) {
                  if (value == "makeAphoto") {

                  }
                  else if (value == "selectAphoto"){

                  }
                },
                itemBuilder: (BuildContext context) => [
                  PopupMenuItem(
                    value: 'makeAphoto',
                    child: Row(
                      mainAxisAlignment: MainAxisAlignment.start,
                      children: [
                        Icon(Icons.camera_alt),
                        SizedBox(width: 10),
                        Text(AppLocalizations.of(context)!.makeAphoto),
                      ],
                    ),
                  ),
                  PopupMenuItem(
                    value: 'selectAphoto',
                    child: Row(
                      mainAxisAlignment: MainAxisAlignment.start,
                      children: [
                        Icon(Icons.photo),
                        SizedBox(width: 10),
                        Text(AppLocalizations.of(context)!.seletAphoto),
                      ],
                    ),
                  ),

                ],
              ),

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
