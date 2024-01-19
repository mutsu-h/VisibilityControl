UnityのInspector Windowに表示するプロパティを列挙型およびbool型で制御する属性

属性の引数
第一引数:string型 変数名を入力
第二引数:object型 判定に利用する列挙子を入力　　　default値 null
第三引数:bool型　 判定条件を切り替える際に使う　　default値 false


sampleプログラム↓
public class Sample : MonoBehaviour
{
    public bool boolean = true;

    //表示される
    [VisibilityControl("boolean")]
    public int hoge;

    //条件が入れ替わるので表示されない
    [VisibilityControl("boolean", null, true)]
    public int hoge2;

    public enum Enumeration
    {
        Show,
        Hide,
    }

    public Enumeration enumeration = Enumeration.Show;

    //表示される
    [VisibilityControl("enumeration", Enumeration.Show)]
    public int hoge3;

     //条件が入れ替わるので表示されない
    [VisibilityControl("enumeration", Enumeration.Show, true)]
    public int hoge4;
}

第二引数で指定する列挙子に関しては、第一引数で指定している変数とは別の列挙型の列挙子でもエラーにはなりません。
列挙子のインデックス番号で比較しているため、別の列挙型の列挙子であっても動作します。


※注意事項※
プログラムの二次頒布を禁止します。
GitHubのリポジトリより各自ダウンロードしてください。
このプログラムの拡張や改造は自由です。拡張および改造を施したプログラムの頒布も可能です。
このプログラムを使用して起きた如何なる問題・損害に対しても一切の責任を負いません。
また拡張・改造されたプログラムに関しても同様に如何なる問題・損害に対しても一切の責任を負いません。
自己責任で使用してください。


最終更新日 2024/01/19 13:00 (日本時間)