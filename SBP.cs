using System;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

namespace BookStarToy.SBP
{
	/// <summary>
	/// SBP文件的数据段类型
	/// </summary>
	public enum SectionType { 
		/// <summary>标志段</summary>
		Flag = 0x0066, 
		/// <summary>文件段</summary>
		File = 0x0067, 
		/// <summary>信息段</summary>
		Info = 0x0068 
	};

	/// <summary>
	/// SBP文件的数据段的基类
	/// </summary>
	public class Section
	{
		/// <summary>段头标志</summary>
		public Byte[]		HEAD_FLAGS;
		/// <summary>段的类型</summary>
		public SectionType	HEAD_TYPE;

		/// <summary>
		/// 构造函数
		/// </summary>
		public Section()
		{
			HEAD_FLAGS = new byte[4] { 0, 0, 0, 0 };
		}

		/// <summary>
		/// 段的大小
		/// </summary>
		/// <value>段的大小</value>
		public virtual UInt16 HEAD_SIZE
		{
			get { return 8; }
		}

		/// <summary>
		/// 写入段信息
		/// </summary>
		/// <param name="bw">写入段的Writer</param>
		public virtual void Write( System.IO.BinaryWriter bw )
		{
			bw.Write( HEAD_FLAGS );
			bw.Write( (UInt16)HEAD_TYPE );
			bw.Write( HEAD_SIZE );
		}

		/// <summary>
		/// 读出段信息
		/// </summary>
		/// <param name="br">读入段的Reader</param>
		public virtual void Read( System.IO.BinaryReader br )
		{
			HEAD_FLAGS = br.ReadBytes( 4 );
			HEAD_TYPE = (SectionType)br.ReadUInt16( );
			br.ReadUInt16( );
		}
	}

	/// <summary>
	/// 标志段，为SBP的第一段，用来标识SBP文件
	/// </summary>
	public class FlagSection : Section
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public FlagSection()
		{
			HEAD_FLAGS = new Byte[4] {(Byte)'L', (Byte)'M', (Byte)' ', (Byte)'\n'};
			HEAD_TYPE = SectionType.Flag;
		}
	}

	/// <summary>
	/// 信息段，包含该电子书相关信息
	/// </summary>
	public class InfoSection : Section
	{
		/// <summary>GUID的图书类型，对应在types.xml</summary>
		public Guid	BOOK_TYPE;

		/// <summary>图书名，UNICODE，字符数最大2^8 /2</summary>
		public string	BOOK_NAME = "";	
	
		/// <summary>图书作者，字符数最大2^8 /2</summary>
		public string	BOOK_WRITER = "";	

		/// <summary>图书来源，字符数最大2^8 /2</summary>
		public string	BOOK_SOURCE = "";	

		/// <summary>图书简介，字符数最大2^16 /2</summary>
		public string	BOOK_BI = "";		

		/// <summary>图书创建者，字符数最大2^8 /2</summary>
		public string	BOOK_CREATOR = "";	

		/// <summary>图书的附加信息，字符数最大2^16 /2</summary>
		public string	BOOK_ADDIN = "";	

		/// <summary>
		/// 构造函数
		/// </summary>
		public InfoSection() : base()
		{
			BOOK_TYPE = new Guid( 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 );
			HEAD_TYPE = SectionType.Info;
		}

		/// <summary>
		/// 数据段头的大小
		/// </summary>
		/// <value>数据段头的大小</value>
		public override UInt16 HEAD_SIZE
		{
			get { return (UInt16)( 18 + ( BOOK_NAME.Length + BOOK_WRITER.Length + BOOK_SOURCE.Length + BOOK_BI.Length + BOOK_CREATOR.Length ) * 2 ); }
		}

		/// <summary>
		/// 附加信息的大小
		/// </summary>
		/// <value>附加信息的大小</value>
		public UInt16 ADDIN_SIZE
		{
			get { return (UInt16)(  BOOK_ADDIN.Length * 2 ); }
		}

		/// <summary>
		/// 写入段信息
		/// </summary>
		/// <param name="bw">写入段的Writer</param>
		public  override void Write( System.IO.BinaryWriter bw )
		{
			base.Write( bw );
			bw.Write( ADDIN_SIZE ); 
			bw.Write( BOOK_TYPE.ToByteArray() ); 
			bw.Write( (Byte)BOOK_NAME.Length ); 
			bw.Write( (Byte)BOOK_WRITER.Length ); 
			bw.Write( (Byte)BOOK_SOURCE.Length ); 
			bw.Write( (UInt16)BOOK_BI.Length ); 
			bw.Write( (Byte)BOOK_CREATOR.Length ); 
			if ( 0 != BOOK_NAME.Length )
				bw.Write( BOOK_NAME.ToCharArray() ); 
			if ( 0 != BOOK_WRITER.Length )
				bw.Write( BOOK_WRITER.ToCharArray() ); 
			if ( 0 != BOOK_SOURCE.Length )
				bw.Write( BOOK_SOURCE.ToCharArray() ); 
			if ( 0 != BOOK_BI.Length )
				bw.Write( BOOK_BI.ToCharArray() ); 
			if ( 0 != BOOK_CREATOR.Length )
				bw.Write( BOOK_CREATOR.ToCharArray() ); 
			if ( 0 != ADDIN_SIZE )
				bw.Write( BOOK_ADDIN.ToCharArray() ); 
		}

		/// <summary>
		/// 读出段信息
		/// </summary>
		/// <param name="br">读入段的Reader</param>
		public override void Read( System.IO.BinaryReader br )
		{
			base.Read( br );

			Guid	BOOK_TYPE;
			UInt16	ADDIN_SIZE, BOOK_BI_Length;
			Byte	BOOK_NAME_Length, BOOK_WRITER_Length, BOOK_SOURCE_Length, BOOK_CREATOR_Length;
			ADDIN_SIZE = br.ReadUInt16(); 
			BOOK_TYPE = new Guid( br.ReadBytes( 16 ) );
			BOOK_NAME_Length = br.ReadByte();
			BOOK_WRITER_Length = br.ReadByte();
			BOOK_SOURCE_Length = br.ReadByte();
			BOOK_BI_Length = br.ReadUInt16();
			BOOK_CREATOR_Length = br.ReadByte();
			if ( BOOK_NAME_Length > 0 )
				BOOK_NAME = new string( br.ReadChars( BOOK_NAME_Length ) );
			if ( BOOK_WRITER_Length > 0 )
				BOOK_WRITER = new string( br.ReadChars( BOOK_WRITER_Length ) );
			if ( BOOK_SOURCE_Length > 0 )
				BOOK_SOURCE = new string( br.ReadChars( BOOK_SOURCE_Length ) );
			if ( BOOK_BI_Length > 0 )
				BOOK_BI = new string( br.ReadChars( BOOK_BI_Length ) );
			if ( BOOK_CREATOR_Length > 0 )
				BOOK_CREATOR = new string( br.ReadChars( BOOK_CREATOR_Length ) );
			if ( ADDIN_SIZE > 0 )
				BOOK_ADDIN = new string( br.ReadChars( ADDIN_SIZE ) );
		}

		/// <summary>
		/// 将此实例的值转换为其等效的字符串表示
		/// </summary>
		/// <returns>此实例的值的字符串表示</returns>
		public override string ToString()
		{
			return String.Format( "书名:{0}\r\n作者:{1}\r\n来源:{2}\r\n简介:{3}\r\n创建者:{4}\r\n附加信息:{5}\r\nGUID:{6}",
				BOOK_NAME, BOOK_WRITER, BOOK_SOURCE, BOOK_BI, BOOK_CREATOR, BOOK_ADDIN, BOOK_TYPE );
		}
	}

	/// <summary>
	/// 压缩类型
	/// </summary>
	public enum FileCompressType 
	{ 
		/// <summary>不压缩</summary>
		Stored = 0, 
		/// <summary>ZIP压缩模式</summary>
		Deflated = 1 
	}

	/// <summary>
	/// 文件段，存储文件数据及相关信息
	/// </summary>
	public class FileSection : Section
	{
		/// <summary>打包以后的尺寸，未压缩则为文件大小</summary>
		public UInt32		PACK_SIZE;
		
		/// <summary>未打包的大小，即原文件大小</summary>
		public UInt32		UNPACK_SIZE;

		/// <summary>文件CRC编码</summary>
		public UInt32		FILE_CRC;	

		/// <summary>文件名，UNICODE，字符数最大2^16 /2</summary>
		public string		FILE_NAME;	

		/// <summary>
		/// 文件内容，UNICODE，字符数最大2^32 /2(不压缩时)
		/// 读取时保存文件开始部分的绝对位置
		///</summary>
		public string		FILE_TEXT;
 
		/// <summary>
		/// 压缩类型，数据保存在HEAD_FLAGS[0]中
		/// </summary>
		/// <value>压缩类型</value>
		public FileCompressType CompressType
		{
			get { return (FileCompressType)HEAD_FLAGS[0];	}
			set { HEAD_FLAGS[0] = (Byte)value;		}
		}

		/// <summary>
		/// 构造函数
		/// </summary>
		public FileSection() : base()
		{
			HEAD_TYPE = SectionType.File;
			PACK_SIZE = UNPACK_SIZE = FILE_CRC = 0;
			CompressType = FileCompressType.Stored;
		}


		/// <summary>
		/// 数据段头的大小
		/// </summary>
		/// <value>数据段头的大小</value>
		public override UInt16 HEAD_SIZE
		{
			get { return (UInt16)( 22 + FILE_NAME.Length * 2 ); }
		}

		/// <summary>
		/// 写入段信息
		/// </summary>
		/// <param name="bw">写入段的Writer</param>
		public  override void Write( System.IO.BinaryWriter bw )
		{
			base.Write( bw );
			PACK_SIZE = UNPACK_SIZE = (UInt32)(FILE_TEXT.Length * 2);
			bw.Write( PACK_SIZE ); 
			bw.Write( UNPACK_SIZE ); 
			bw.Write( FILE_CRC ); 
			bw.Write( (UInt16)FILE_NAME.Length ); 
			bw.Write( FILE_NAME.ToCharArray() ); 

			// 输出文件内容
			switch ( CompressType )
			{
				case FileCompressType.Stored:
					bw.Write( FILE_TEXT.ToCharArray() ); 
					break;
				case FileCompressType.Deflated: 
				{
					DeflaterOutputStream deflaterStream = new DeflaterOutputStream(bw.BaseStream);
					deflaterStream.IsStreamOwner = false;
					System.IO.BinaryWriter bwZip = new System.IO.BinaryWriter(deflaterStream, System.Text.Encoding.Unicode); 
					bwZip.Write( FILE_TEXT.ToCharArray() ); 
					bwZip.Close();
					break;
				}
			}
		}

		/// <summary>
		/// 读出段信息
		/// </summary>
		/// <param name="br">读入段的Reader</param>
		public override void Read( System.IO.BinaryReader br )
		{
			base.Read( br );
			
			UInt16	FILE_NAME_Length;
			PACK_SIZE = br.ReadUInt32();
			UNPACK_SIZE = br.ReadUInt32(); 
			FILE_CRC = br.ReadUInt32();
			FILE_NAME_Length = br.ReadUInt16();
			FILE_NAME = new string( br.ReadChars( FILE_NAME_Length ) );
			FILE_TEXT = br.BaseStream.Position.ToString();  
			br.BaseStream.Seek( PACK_SIZE, System.IO.SeekOrigin.Current );
		}	
	}

	/// <summary>
	/// SBP文件创建器
	/// </summary>
	public class SBP_Creator
	{
		/// <summary>SBP文件的Writer</summary>
		protected System.IO.BinaryWriter bw = null;

		/// <summary>
		/// 创建SBP文件
		/// </summary>
		/// <param name="strFilename">文件名</param>
		public void Create( string strFilename )
		{
			// 创建输出流
			System.IO.FileStream fs = new System.IO.FileStream( strFilename, System.IO.FileMode.Create );
			bw = new System.IO.BinaryWriter( fs, System.Text.Encoding.Unicode ); 

			// 写入标志段
			FlagSection	flagsect = new FlagSection();
			AddSection( flagsect );
		}

		/// <summary>
		/// 关闭当前打开的SBP文件
		/// </summary>
		public void Close()
		{
			if ( null != bw )
				bw.Close(); 
		}

		/// <summary>
		/// 添加数据段
		/// </summary>
		/// <param name="sect">数据段</param>
		public void AddSection( Section sect ) 
		{
			sect.Write( bw ); 
			bw.Flush(); 
		}
	}

	/// <summary>
	/// SBP的打开器，用来获取SBP文件内数据段
	/// </summary>
	public class SBP_Reader
	{
		/// <summary>文件名</summary>
		protected string			filename = "";

		/// <summary>数据段列表，用来存储SBP所包含的所有数据段</summary>
		protected System.Collections.ArrayList	Sections = new System.Collections.ArrayList();
		
		/// <summary>
		/// 数据段的个数，文件未打开返回0 
		/// </summary>
		public int Count
		{
			get { return Sections.Count; }
		}

		/// <summary>
		/// 通过下标获取数据段
		/// </summary>
		/// <value name="nIndex">返回的数据段</value>
		public Section this[int nIndex]
		{
			get {
				return ( nIndex >= Sections.Count || nIndex < 0 ) ? null : ( Section )Sections[nIndex];
			}
		}		

		/// <summary>
		/// 获取信息段，一般SBP的信息段是唯一的，如果有多个则返回第一段
		/// </summary>
		/// <returns>所得的信息段，没有找到则返回null</returns>
		public InfoSection GetInfoSection()
		{
			for ( int i = 0; i < Count; i++)
			{
				if ( SectionType.Info == this[i].HEAD_TYPE )
					return ( InfoSection )this[i];
			}
			return null;
		}

		/// <summary>
		/// 获取文件段的信息
		/// </summary>
		/// <param name="fileSect">文件段</param>
		/// <returns>段的信息</returns>
		public string GetText( FileSection fileSect )
		{
			// 创建输入流
			string strTemp = "";
			System.IO.FileStream fs = new System.IO.FileStream( filename, System.IO.FileMode.Open );
			fs.Seek( Int32.Parse( fileSect.FILE_TEXT ), System.IO.SeekOrigin.Current );
			switch ( fileSect.CompressType )
			{
				case FileCompressType.Stored:
				{
					System.IO.BinaryReader br = new System.IO.BinaryReader( fs, System.Text.Encoding.Unicode ); 
					strTemp = new string( br.ReadChars( (int) fileSect.UNPACK_SIZE ) ); 
					br.Close();
					break;
				}
				case FileCompressType.Deflated:
				{
					InflaterInputStream inflaterStream = new InflaterInputStream(fs);
					System.IO.BinaryReader br = new System.IO.BinaryReader(inflaterStream, System.Text.Encoding.Unicode);   
					strTemp = new string( br.ReadChars( (int) fileSect.UNPACK_SIZE ) ); 
					br.Close();
					break;
				}
				default:
					return null;
			}

			fs.Close();
			return strTemp;
		}

		/// <summary>
		/// 装载SBP文件，并填充所有的数据段
		/// </summary>
		/// <param name="strFilename">文件名</param>
		public void Load( string strFilename )
		{
			try{
				// 创建输入流
				System.IO.FileStream fs = new System.IO.FileStream( strFilename, System.IO.FileMode.Open );
				System.IO.BinaryReader br = new System.IO.BinaryReader( fs, System.Text.Encoding.Unicode ); 

				// 读取标志段并判断
				FlagSection	flagsect = new FlagSection();
				flagsect.Read( br );
				
				// 
				while ( fs.Position < fs.Length )
				{
					Section sect = null;

					flagsect.Read( br );
					switch ( flagsect.HEAD_TYPE )
					{
						case SectionType.Info:
							sect = new InfoSection();
							break;
						case SectionType.File:
							sect = new FileSection();
							break;
						default:
							throw new SBP_Exception( SBP_Exception.ErrorCode.UnknownSection, null );
					}
					br.BaseStream.Seek( -flagsect.HEAD_SIZE, System.IO.SeekOrigin.Current );

					sect.Read( br );
					Sections.Add( sect );
				}
				br.Close(); 
			} catch ( Exception ex ){
				throw new SBP_Exception( SBP_Exception.ErrorCode.LoadSectionFail, ex.Message );
			}

			filename = strFilename;
		}
	}

	/// <summary>
	/// SBP的异常类
	/// </summary>
	public class SBP_Exception : System.ApplicationException 
	{
		/// <summary>错误码枚举</summary>
		public enum ErrorCode { 
			/// <summary>未知错误</summary>
			Unknown, 

			/// <summary>未知段错误</summary>
			UnknownSection, 

			/// <summary>段装载错误</summary>
			LoadSectionFail 
		}

		/// <summary>错误代码</summary>
		ErrorCode Error = ErrorCode.Unknown;

		/// <summary>错误信息</summary>
		string strMessage = null;

		/// <summary>已重写，返回当前的错误码的错误信息</summary>
		public override string Message 
		{
			get 
			{
				switch ( Error )
				{
					case ErrorCode.UnknownSection:return "无法识别的文件段";
					case ErrorCode.LoadSectionFail:return "文件装载失败，原因：" + strMessage;
					default:
						return  "未知错误";
				}
			}
		}

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="errcode">错误码</param>
		/// <param name="msg">错误信息</param>
		public SBP_Exception ( ErrorCode errcode, string msg )
		{
			Error = errcode;
			strMessage = msg;
		}
	}
}
