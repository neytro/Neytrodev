import 'package:sqflite/sqflite.dart';
import 'package:path/path.dart';

class DatabaseHelper {
  static final DatabaseHelper _instance = DatabaseHelper._internal();
  factory DatabaseHelper() => _instance;
  DatabaseHelper._internal();

  Database? _db;

  Future<Database> get database async {
    if (_db != null) return _db!;
    _db = await _initDb();
    return _db!;
  }

  Future<Database> _initDb() async {
    final dbPath = await getDatabasesPath();
    final path = join(dbPath, 'my_database.db');

    return await openDatabase(
      path,
      version: 1,
      onCreate: (db, version) async {
        await db.execute('''
          CREATE TABLE items (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            name TEXT
          )
        ''');
      },
    );
  }
  Future<void> addItem(String name) async {
    final db = await DatabaseHelper().database;
    await db.insert(
      'items',
      {'name': name},
      conflictAlgorithm: ConflictAlgorithm.replace,
    );
  }
  Future<void> updateItem(int id, String newName) async {
    final db = await DatabaseHelper().database;
    await db.update(
      'items',
      {'name': newName},
      where: 'id = ?',
      whereArgs: [id],
    );
  }
  Future<void> deleteItem(int id) async {
    final db = await DatabaseHelper().database;
    await db.delete(
      'items',
      where: 'id = ?',
      whereArgs: [id],
    );
  }
  Future<List<Map<String, dynamic>>> getItems() async {
    final db = await DatabaseHelper().database;
    return await db.query('items');
  }
}