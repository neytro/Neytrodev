import 'dart:async';

import 'package:corblist/Repository/Item.dart';
import 'package:flutter/widgets.dart';
import 'package:path/path.dart';
import 'package:sqflite/sqflite.dart';

class DatabaseHelper {
  late Future<Database>  _database;
  DatabaseHelper();
  Future<void> initDatabase() async {
    _database = openDatabase(

      join(await getDatabasesPath(), 'shoppinglist.db'),
      onCreate: (db, version) {
        return db.execute(
          'CREATE TABLE List(id INTEGER PRIMARY KEY, text TEXT, checked BOOLEAN)',
        );
      },
      version: 1,
    );
  }


  Future<void> insertItem(Item item) async {
    final db = await _database;

    await db.insert(
      'list',
      item.toMap(),
      conflictAlgorithm: ConflictAlgorithm.replace,
    );
  }
}

