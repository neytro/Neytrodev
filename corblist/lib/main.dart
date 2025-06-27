import 'package:corblist/l10n/app_localizations.dart';
import 'package:flutter/material.dart';
import 'package:flutter_localizations/flutter_localizations.dart';

void main() {
  runApp(const MyApp());
}

class Item {
  bool checked;
  String text;
  Item({required this.checked, required this.text});
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Localizations Sample App',
      localizationsDelegates: [
        AppLocalizations.delegate, // Add this line
        GlobalMaterialLocalizations.delegate,
        GlobalWidgetsLocalizations.delegate,
        GlobalCupertinoLocalizations.delegate,
      ],
      supportedLocales: [
        Locale('pl'),
        Locale('ar'),
        Locale('fr'),
        Locale('zh'),
        Locale('ru'),
        Locale('es'),
        Locale('de'),
        Locale('en'),
      ],
      localeResolutionCallback: (locale, supportedLocales) {
        if (locale == null) return const Locale('en');

        for (var supportedLocale in supportedLocales) {
          if (supportedLocale.languageCode == locale.languageCode) {
            return supportedLocale;
          }
        }

        return const Locale('en');
      },
      theme: ThemeData(
        // This is the theme of your application.
        //
        // TRY THIS: Try running your application with "flutter run". You'll see
        // the application has a purple toolbar. Then, without quitting the app,
        // try changing the seedColor in the colorScheme below to Colors.green
        // and then invoke "hot reload" (save your changes or press the "hot
        // reload" button in a Flutter-supported IDE, or press "r" if you used
        // the command line to start the app).
        //
        // Notice that the counter didn't reset back to zero; the application
        // state is not lost during the reload. To reset the state, use hot
        // restart instead.
        //
        // This works for code too, not just values: Most code changes can be
        // tested with just a hot reload.
        colorScheme: ColorScheme.fromSeed(seedColor: Colors.deepPurple),
      ),
      home: const MyHomePage(title: ''),
    );
  }
}

class MyHomePage extends StatefulWidget {
  const MyHomePage({super.key, required this.title});

  // This widget is the home page of your application. It is stateful, meaning
  // that it has a State object (defined below) that contains fields that affect
  // how it looks.

  // This class is the configuration for the state. It holds the values (in this
  // case the title) provided by the parent (in this case the App widget) and
  // used by the build method of the State. Fields in a Widget subclass are
  // always marked "final".

  final String title;

  @override
  State<MyHomePage> createState() => _MyHomePageState();
}

class _MyHomePageState extends State<MyHomePage> {
  int _counter = 0;
  List<Item> items = List.generate(10, (index) => Item(checked: false, text: 'Item $index'),
  );
  Widget _buildItem({required int index, required bool isBeingDragged}) {
    return ListTile(
      key: ValueKey(items[index]),
      title: Text(items[index].text),
      tileColor: isBeingDragged ? Colors.lightBlue : Colors.white,
    );
  }
  void _incrementCounter() {
    setState(() {
      // This call to setState tells the Flutter framework that something has
      // changed in this State, which causes it to rerun the build method below
      // so that the display can reflect the updated values. If we changed
      // _counter without calling setState(), then the build method would not be
      // called again, and so nothing would appear to happen.
      _counter++;
    });
  }

  @override
  Widget build(BuildContext context) {
    // This method is rerun every time setState is called, for instance as done
    // by the _incrementCounter method above.
    //
    // The Flutter framework has been optimized to make rerunning build methods
    // fast, so that you can just rebuild anything that needs updating rather
    // than having to individually change instances of widgets.

    return Scaffold(
      appBar: AppBar(
        actions: [
          IconButton(icon: Icon(Icons.search), onPressed: () {}),
          IconButton(icon: Icon(Icons.add), onPressed: () {}),

          PopupMenuButton<String>(
            onSelected: (value) {},
            itemBuilder: (BuildContext context) => [
              PopupMenuItem(
                value: 'clearlist',
                child: Row(
                  mainAxisAlignment: MainAxisAlignment.spaceBetween,
                  children: [
                    Icon(Icons.delete_sweep_rounded),
                    Text(AppLocalizations.of(context)!.clearlist),
                  ],
                ),
              ),
              PopupMenuItem(
                value: 'sharewhatsapp',
                child: Row(
                  mainAxisAlignment: MainAxisAlignment.spaceBetween,
                  children: [
                    Icon(Icons.share),
                    Text(AppLocalizations.of(context)!.sharewhatsapp),
                  ],
                ),
              ),
            ],
          ),
        ],
        // TRY THIS: Try changing the color here to a specific color (to
        // Colors.amber, perhaps?) and trigger a hot reload to see the AppBar
        // change color while the other colors stay the same.
        backgroundColor: Theme.of(context).colorScheme.inversePrimary,
        // Here we take the value from the MyHomePage object that was created by
        // the App.build method, and use it to set our appbar title.
        title: Text(widget.title),
      ),
  
      body: ReorderableListView.builder(
        itemCount: items.length,
        onReorder: (oldIndex, newIndex) {
          setState(() {
            if (newIndex > oldIndex) newIndex--;
            final item = items.removeAt(oldIndex);
            items.insert(newIndex, item);

          });
        },
        proxyDecorator: (child, index, animation) => Material(
          type: MaterialType.transparency,
          child: _buildItem(index: index, isBeingDragged: true),
        ),

        itemBuilder: (context, index) {
          final item = items[index];

          return Container(
            key: ValueKey(item.text),
            decoration: item.checked ? BoxDecoration(color: Colors.redAccent):
            BoxDecoration(border: Border(bottom: BorderSide(color: Theme.of(context).dividerColor, width: 0.5))),

            child: ListTile(

              title: Row(

                children: [
                  Checkbox(
                    value: item.checked,
                    onChanged: (value) {
                      setState(() {
                        item.checked = value ?? false;
                      });
                    },
                  ),
                  Expanded(
                    child: Text(item.text),
                  ),
                  Column(
                    mainAxisSize: MainAxisSize.min,
                    children: [

                      IconButton(
                        icon: const Icon(Icons.camera_alt),
                        onPressed: () {
                          // Akcja info
                        },
                      ),
                      if (index < items.length - 1)
                        const Divider(
                          height: 5,
                          thickness: 5,
                          color: Colors.lightBlue,
                        ),
                    ],

                  ),
                  Divider(
                    height: 1,
                    thickness: 1,
                    color: Colors.lightBlue,
                  ),
                ],
              ),
            ),
          );
        },
      ),
      // This trailing comma makes auto-formatting nicer for build methods.
    );
  }
}
