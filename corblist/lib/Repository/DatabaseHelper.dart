import 'dart:async';
import 'package:corblist/Repository/Item.dart';
import 'package:flutter/widgets.dart';
import 'package:path/path.dart';
import 'package:sqflite/sqflite.dart';


class DatabaseHelper {
  late Future<Database> database;

  DatabaseHelper() {
    database = _initDatabase();
  }

  Future<Database> _initDatabase() async {
    return openDatabase(
      join(await getDatabasesPath(), 'shoppinglist.db'),
      version: 11,
      onCreate: (db, version) async {
        await db.execute(
          'CREATE TABLE list(id INTEGER PRIMARY KEY, checked INTEGER, text TEXT)',
        );
      },
    );
  }

  Future<void> insertItem(Item item) async {
    final db = await database;

    await db.insert(
      'list',
      item.toMap(),
      conflictAlgorithm: ConflictAlgorithm.replace,
    );
  }
  Future<List<Item>> getItems() async {
    print("2222222222222222222");
    final db = await database;


    final List<Map<String, Object?>> itemMaps = await db.query('list');

    return List.generate(itemMaps.length, (i) {
      return Item.fromMap(itemMaps[i]);
    });
  }
}

