# ItemInfoMaker

## 使用方法
1. 上部のリストで入力データを設定する  
基本的には上に設定したものが優先的に使用される  
全てのファイルを登録しておく必要はありません  
必要に応じて設定を追加、削除して下さい
2. チェックボックスのオプションを選択する
3. ItemInfo出力でファイルを出力する

## 入力データの種類
* `idnum2itemdisplaynametable`  
鑑定済みアイテム名をピックアップする  
`data.grf`から抽出
* `idnum2itemdesctable`  
鑑定済みアイテムの説明をピックアップする  
`data.grf`から抽出
* `idnum2itemresnametable`  
鑑定済みアイテムのリソースファイルをピックアップする  
`data.grf`から抽出
* `num2itemdisplaynametable`  
未鑑定アイテム名をピックアップする  
`data.grf`から抽出
* `num2itemdesctable`  
未鑑定アイテムの説明をピックアップする  
`data.grf`から抽出
* `num2itemresnametable`  
未鑑定アイテムのリソースファイルをピックアップする  
`data.grf`から抽出
* `itemslotcounttable`  
スロット数をピックアップする  
後述の`itemdb` を使用する場合は基本的に不要  
* `itemclassnumtable`  
View値を指定する  
個別スプライトが存在する武器等で使用する  
記載フォーマットは`idnum2itemresnametable`等と同じで`ID#View値#`と記載していく
* `iteminfo`  
全ての項目をピックアップする  
本家データにオリジナルアイテムの項目を追加するときに使用  
* `itemdb`  
`item_db.txt`や`item_db_add.txt`を指定する  
鑑定済みアイテム名、スロット数、View値、コスチューム設定をピックアップする  
`iteminfo`よりも高い優先度で`itemdb`のファイルを設定すると、  
武器のView値がデフォルトのものに戻るので、  
`iteminfo`よりも低い優先度で設定すること

## オプション
* IDを2Byteに制限する(ItemID拡張前のRagexe用)  
65536以上のIDを割り当てられているアイテムを、65536で割った余りのIDで出力する  
IDを4Byteに拡張前はIDの下位2Byteのみでiteminfoから検索を行うため、古いRagexeを行う場合はチェックすること  
IDを65536で割った余りのIDに変換した結果、IDの重複が発生した場合は、実行ファイルと同じフォルダに置いてある`DuplicateConfig.xml`を元にどちらを採用するか判断する  
`DuplicateConfig.xml`に記載がない場合は、小さいIDのものが削除される  
* エラーにならないように不足箇所にダミー設定を入力する  
アイテム名やリソースファイル設定が存在しない場合に、エラーにならないように適当に設定を行う
* IDでソートする  
出力時にIDでソートを行う  
チェックしなかった場合はよみとった順(低優先度のファイルの先頭から順番)で出力する
* costumeを出力する  
新しいRagexe用  
詳細不明なので適当です  

## その他
exeファイルと同じ階層にある`itemInfo_footer.lub`を最後に結合して出力する
必要に応じてファイルを置き換えること

## 設定サンプル
```
<?xml version="1.0" encoding="utf-8"?>
<root>
  <LimitItemID>true</LimitItemID>
  <FillDummy>true</FillDummy>
  <SortByID>true</SortByID>
  <Costume>false</Costume>
  <iteminfo_path>C:\RO\iteminfo_Sak2.lub</iteminfo_path>
  <itemdb_path></itemdb_path>
  <Input>
    <type>itemclassnumtable</type>
    <path>C:\RO\itemclassnumtable.txt</path>
  </Input>
  <Input>
    <type>iteminfo</type>
    <path>C:\RO\iteminfo_original_difflub.txt</path>
  </Input>
  <Input>
    <type>num2itemresnametable</type>
    <path>C:\RO\num2itemresnametable.txt</path>
  </Input>
  <Input>
    <type>num2itemdesctable</type>
    <path>C:\RO\num2itemdesctable.txt</path>
  </Input>
  <Input>
    <type>num2itemdisplaynametable</type>
    <path>C:\RO\num2itemdisplaynametable.txt</path>
  </Input>
  <Input>
    <type>idnum2itemresnametable</type>
    <path>C:\RO\idnum2itemresnametable.txt</path>
  </Input>
  <Input>
    <type>idnum2itemdesctable</type>
    <path>C:\RO\idnum2itemdesctable.txt</path>
  </Input>
  <Input>
    <type>idnum2itemdisplaynametable</type>
    <path>C:\RO\idnum2itemdisplaynametable.txt</path>
  </Input>
  <Input>
    <type>itemdb</type>
    <path>E:\ROEmu\ServerAuriga\db\addon\item_db_add.txt</path>
  </Input>
  <Input>
    <type>itemdb</type>
    <path>E:\ROEmu\ServerAuriga\db\item_db.txt</path>
  </Input>
</root>
```