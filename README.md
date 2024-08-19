# ①課題番号-プロダクト名

LINE風チャットアプリ_Unity版

## ②課題内容（どんな作品か）

- firebaseのCloud Firestoreを使ったチャットアプリの作成
- Unity上で実行し、送信またはその他ボタンをクリックするとアプリ画面上にチャットが投稿される
- 送信クリック：画面右側、その他クリック：画面左側にチャットが投稿されていく
- Realtime DatabaseではなくFirestore Databseを使って作成（サンプルプログラムを参考にしたため）

## ③DEMO
https://drive.google.com/file/d/1WKDqEnGH_RFvq01hqZQpjAeT7asIxZLy/view?usp=sharing
（Googleドライブに実行画面の動画あげてます）

## ④作ったアプリケーション用のIDまたはPasswordがある場合

## ⑤工夫した点・こだわった点

- UnityでLINE風のチャットアプリを作成
- UI（InputFieldやButton）を使い操作できるようにした
- 参考にしたサイトではdbからチャットのログデータを参照してチャット画面に表示するまでなかったが、dbからログデータを取得し実行のタイミングで過去のやり取りが表示されるようにした

## ⑥難しかった点・次回トライしたいこと(又は機能)

- Unity上でUIを作成したが設定等が難しかった
- 最新のUI toolkitは使い方がわからず挑戦できなかったが使えるようになりたい
  - HTML/CSSのような感じでUnityのUIが作成できる
- ３Dでアニメーションを作成してスタンプ機能を作りたかったが時間がないため断念  

## ⑦質問・疑問・感想、シェアしたいこと等なんでも
- [シェアしたいこと（備忘）]
  -　1. firebase関連のJsonファイルは「Assets」配下に「StreamingAssets」 を作成しおく必要がある
    -　公式ドキュメント通りに進めるとエラーが起きる
  - 2. Unityのバージョンにfirebaseが追いついていない場合もあるので今回は「2022.3.41f1」で課題作成を進めた
    - Unityのバージョンが変わるとこれまで動いていたプログラムが動かずエラーを吐くケースが多い 
- [質問]
- [感想]
  - Unityを久々に触ってC#でプログラミングしたがバージョンが変わっているなどの影響で環境設定から時間がかかった。
  - firebase　×　Unityのプログラムは初めてだったが公式ドキュメントやQitaを使いながら進めることができた。 
- [参考記事]
  - 1. https://firebase.google.com/docs/unity/setup?hl=ja
  - 2. https://hiyotama.hatenablog.com/entry/2019/08/23/110000
