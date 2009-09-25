using System;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

namespace BookStarToy.SBP
{
	/// <summary>
	/// SBP�ļ������ݶ�����
	/// </summary>
	public enum SectionType { 
		/// <summary>��־��</summary>
		Flag = 0x0066, 
		/// <summary>�ļ���</summary>
		File = 0x0067, 
		/// <summary>��Ϣ��</summary>
		Info = 0x0068 
	};

	/// <summary>
	/// SBP�ļ������ݶεĻ���
	/// </summary>
	public class Section
	{
		/// <summary>��ͷ��־</summary>
		public Byte[]		HEAD_FLAGS;
		/// <summary>�ε�����</summary>
		public SectionType	HEAD_TYPE;

		/// <summary>
		/// ���캯��
		/// </summary>
		public Section()
		{
			HEAD_FLAGS = new byte[4] { 0, 0, 0, 0 };
		}

		/// <summary>
		/// �εĴ�С
		/// </summary>
		/// <value>�εĴ�С</value>
		public virtual UInt16 HEAD_SIZE
		{
			get { return 8; }
		}

		/// <summary>
		/// д�����Ϣ
		/// </summary>
		/// <param name="bw">д��ε�Writer</param>
		public virtual void Write( System.IO.BinaryWriter bw )
		{
			bw.Write( HEAD_FLAGS );
			bw.Write( (UInt16)HEAD_TYPE );
			bw.Write( HEAD_SIZE );
		}

		/// <summary>
		/// ��������Ϣ
		/// </summary>
		/// <param name="br">����ε�Reader</param>
		public virtual void Read( System.IO.BinaryReader br )
		{
			HEAD_FLAGS = br.ReadBytes( 4 );
			HEAD_TYPE = (SectionType)br.ReadUInt16( );
			br.ReadUInt16( );
		}
	}

	/// <summary>
	/// ��־�Σ�ΪSBP�ĵ�һ�Σ�������ʶSBP�ļ�
	/// </summary>
	public class FlagSection : Section
	{
		/// <summary>
		/// ���캯��
		/// </summary>
		public FlagSection()
		{
			HEAD_FLAGS = new Byte[4] {(Byte)'L', (Byte)'M', (Byte)' ', (Byte)'\n'};
			HEAD_TYPE = SectionType.Flag;
		}
	}

	/// <summary>
	/// ��Ϣ�Σ������õ����������Ϣ
	/// </summary>
	public class InfoSection : Section
	{
		/// <summary>GUID��ͼ�����ͣ���Ӧ��types.xml</summary>
		public Guid	BOOK_TYPE;

		/// <summary>ͼ������UNICODE���ַ������2^8 /2</summary>
		public string	BOOK_NAME = "";	
	
		/// <summary>ͼ�����ߣ��ַ������2^8 /2</summary>
		public string	BOOK_WRITER = "";	

		/// <summary>ͼ����Դ���ַ������2^8 /2</summary>
		public string	BOOK_SOURCE = "";	

		/// <summary>ͼ���飬�ַ������2^16 /2</summary>
		public string	BOOK_BI = "";		

		/// <summary>ͼ�鴴���ߣ��ַ������2^8 /2</summary>
		public string	BOOK_CREATOR = "";	

		/// <summary>ͼ��ĸ�����Ϣ���ַ������2^16 /2</summary>
		public string	BOOK_ADDIN = "";	

		/// <summary>
		/// ���캯��
		/// </summary>
		public InfoSection() : base()
		{
			BOOK_TYPE = new Guid( 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 );
			HEAD_TYPE = SectionType.Info;
		}

		/// <summary>
		/// ���ݶ�ͷ�Ĵ�С
		/// </summary>
		/// <value>���ݶ�ͷ�Ĵ�С</value>
		public override UInt16 HEAD_SIZE
		{
			get { return (UInt16)( 18 + ( BOOK_NAME.Length + BOOK_WRITER.Length + BOOK_SOURCE.Length + BOOK_BI.Length + BOOK_CREATOR.Length ) * 2 ); }
		}

		/// <summary>
		/// ������Ϣ�Ĵ�С
		/// </summary>
		/// <value>������Ϣ�Ĵ�С</value>
		public UInt16 ADDIN_SIZE
		{
			get { return (UInt16)(  BOOK_ADDIN.Length * 2 ); }
		}

		/// <summary>
		/// д�����Ϣ
		/// </summary>
		/// <param name="bw">д��ε�Writer</param>
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
		/// ��������Ϣ
		/// </summary>
		/// <param name="br">����ε�Reader</param>
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
		/// ����ʵ����ֵת��Ϊ���Ч���ַ�����ʾ
		/// </summary>
		/// <returns>��ʵ����ֵ���ַ�����ʾ</returns>
		public override string ToString()
		{
			return String.Format( "����:{0}\r\n����:{1}\r\n��Դ:{2}\r\n���:{3}\r\n������:{4}\r\n������Ϣ:{5}\r\nGUID:{6}",
				BOOK_NAME, BOOK_WRITER, BOOK_SOURCE, BOOK_BI, BOOK_CREATOR, BOOK_ADDIN, BOOK_TYPE );
		}
	}

	/// <summary>
	/// ѹ������
	/// </summary>
	public enum FileCompressType 
	{ 
		/// <summary>��ѹ��</summary>
		Stored = 0, 
		/// <summary>ZIPѹ��ģʽ</summary>
		Deflated = 1 
	}

	/// <summary>
	/// �ļ��Σ��洢�ļ����ݼ������Ϣ
	/// </summary>
	public class FileSection : Section
	{
		/// <summary>����Ժ�ĳߴ磬δѹ����Ϊ�ļ���С</summary>
		public UInt32		PACK_SIZE;
		
		/// <summary>δ����Ĵ�С����ԭ�ļ���С</summary>
		public UInt32		UNPACK_SIZE;

		/// <summary>�ļ�CRC����</summary>
		public UInt32		FILE_CRC;	

		/// <summary>�ļ�����UNICODE���ַ������2^16 /2</summary>
		public string		FILE_NAME;	

		/// <summary>
		/// �ļ����ݣ�UNICODE���ַ������2^32 /2(��ѹ��ʱ)
		/// ��ȡʱ�����ļ���ʼ���ֵľ���λ��
		///</summary>
		public string		FILE_TEXT;
 
		/// <summary>
		/// ѹ�����ͣ����ݱ�����HEAD_FLAGS[0]��
		/// </summary>
		/// <value>ѹ������</value>
		public FileCompressType CompressType
		{
			get { return (FileCompressType)HEAD_FLAGS[0];	}
			set { HEAD_FLAGS[0] = (Byte)value;		}
		}

		/// <summary>
		/// ���캯��
		/// </summary>
		public FileSection() : base()
		{
			HEAD_TYPE = SectionType.File;
			PACK_SIZE = UNPACK_SIZE = FILE_CRC = 0;
			CompressType = FileCompressType.Stored;
		}


		/// <summary>
		/// ���ݶ�ͷ�Ĵ�С
		/// </summary>
		/// <value>���ݶ�ͷ�Ĵ�С</value>
		public override UInt16 HEAD_SIZE
		{
			get { return (UInt16)( 22 + FILE_NAME.Length * 2 ); }
		}

		/// <summary>
		/// д�����Ϣ
		/// </summary>
		/// <param name="bw">д��ε�Writer</param>
		public  override void Write( System.IO.BinaryWriter bw )
		{
			base.Write( bw );
			PACK_SIZE = UNPACK_SIZE = (UInt32)(FILE_TEXT.Length * 2);
			bw.Write( PACK_SIZE ); 
			bw.Write( UNPACK_SIZE ); 
			bw.Write( FILE_CRC ); 
			bw.Write( (UInt16)FILE_NAME.Length ); 
			bw.Write( FILE_NAME.ToCharArray() ); 

			// ����ļ�����
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
		/// ��������Ϣ
		/// </summary>
		/// <param name="br">����ε�Reader</param>
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
	/// SBP�ļ�������
	/// </summary>
	public class SBP_Creator
	{
		/// <summary>SBP�ļ���Writer</summary>
		protected System.IO.BinaryWriter bw = null;

		/// <summary>
		/// ����SBP�ļ�
		/// </summary>
		/// <param name="strFilename">�ļ���</param>
		public void Create( string strFilename )
		{
			// ���������
			System.IO.FileStream fs = new System.IO.FileStream( strFilename, System.IO.FileMode.Create );
			bw = new System.IO.BinaryWriter( fs, System.Text.Encoding.Unicode ); 

			// д���־��
			FlagSection	flagsect = new FlagSection();
			AddSection( flagsect );
		}

		/// <summary>
		/// �رյ�ǰ�򿪵�SBP�ļ�
		/// </summary>
		public void Close()
		{
			if ( null != bw )
				bw.Close(); 
		}

		/// <summary>
		/// ������ݶ�
		/// </summary>
		/// <param name="sect">���ݶ�</param>
		public void AddSection( Section sect ) 
		{
			sect.Write( bw ); 
			bw.Flush(); 
		}
	}

	/// <summary>
	/// SBP�Ĵ�����������ȡSBP�ļ������ݶ�
	/// </summary>
	public class SBP_Reader
	{
		/// <summary>�ļ���</summary>
		protected string			filename = "";

		/// <summary>���ݶ��б������洢SBP���������������ݶ�</summary>
		protected System.Collections.ArrayList	Sections = new System.Collections.ArrayList();
		
		/// <summary>
		/// ���ݶεĸ������ļ�δ�򿪷���0 
		/// </summary>
		public int Count
		{
			get { return Sections.Count; }
		}

		/// <summary>
		/// ͨ���±��ȡ���ݶ�
		/// </summary>
		/// <value name="nIndex">���ص����ݶ�</value>
		public Section this[int nIndex]
		{
			get {
				return ( nIndex >= Sections.Count || nIndex < 0 ) ? null : ( Section )Sections[nIndex];
			}
		}		

		/// <summary>
		/// ��ȡ��Ϣ�Σ�һ��SBP����Ϣ����Ψһ�ģ�����ж���򷵻ص�һ��
		/// </summary>
		/// <returns>���õ���Ϣ�Σ�û���ҵ��򷵻�null</returns>
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
		/// ��ȡ�ļ��ε���Ϣ
		/// </summary>
		/// <param name="fileSect">�ļ���</param>
		/// <returns>�ε���Ϣ</returns>
		public string GetText( FileSection fileSect )
		{
			// ����������
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
		/// װ��SBP�ļ�����������е����ݶ�
		/// </summary>
		/// <param name="strFilename">�ļ���</param>
		public void Load( string strFilename )
		{
			try{
				// ����������
				System.IO.FileStream fs = new System.IO.FileStream( strFilename, System.IO.FileMode.Open );
				System.IO.BinaryReader br = new System.IO.BinaryReader( fs, System.Text.Encoding.Unicode ); 

				// ��ȡ��־�β��ж�
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
	/// SBP���쳣��
	/// </summary>
	public class SBP_Exception : System.ApplicationException 
	{
		/// <summary>������ö��</summary>
		public enum ErrorCode { 
			/// <summary>δ֪����</summary>
			Unknown, 

			/// <summary>δ֪�δ���</summary>
			UnknownSection, 

			/// <summary>��װ�ش���</summary>
			LoadSectionFail 
		}

		/// <summary>�������</summary>
		ErrorCode Error = ErrorCode.Unknown;

		/// <summary>������Ϣ</summary>
		string strMessage = null;

		/// <summary>����д�����ص�ǰ�Ĵ�����Ĵ�����Ϣ</summary>
		public override string Message 
		{
			get 
			{
				switch ( Error )
				{
					case ErrorCode.UnknownSection:return "�޷�ʶ����ļ���";
					case ErrorCode.LoadSectionFail:return "�ļ�װ��ʧ�ܣ�ԭ��" + strMessage;
					default:
						return  "δ֪����";
				}
			}
		}

		/// <summary>
		/// ���캯��
		/// </summary>
		/// <param name="errcode">������</param>
		/// <param name="msg">������Ϣ</param>
		public SBP_Exception ( ErrorCode errcode, string msg )
		{
			Error = errcode;
			strMessage = msg;
		}
	}
}
