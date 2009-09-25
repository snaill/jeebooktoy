using System;
using System.Collections;
using System.Threading;

namespace BookStarToy
{
	/// <summary>���������̵߳Ĵ���</summary>
	public delegate Thread CreateDownload( Object o );

	enum DownloadStatus
	{
		Ready,
		Downloading,
		Stop
	}

	class DownloadItem
	{
		/// <summary>���������</summary>
		public Object		DownloadInfomation = null;

		/// <summary>�����߳�</summary>
		public Thread		DownloadThread = null;

		/// <summary>������״̬</summary>
		public DownloadStatus	Status = DownloadStatus.Ready;
	}

	/// <summary>
	/// DownloadService ��ժҪ˵����
	/// </summary>
	public class DownloadService
	{
		/// <summary>���ǰ�����߳���</summary>
		const int THREAD_MAXCOUNT = 10;

		/// <summary>�������б�</summary>
		protected ArrayList		m_aItems = new ArrayList();

		/// <summary>�������״̬�߳�</summary>
		protected Thread		m_aStatusThread = null;

		/// <summary>���������̵߳Ĵ���ʵ��</summary>
		protected ParameterizedThreadStart	D_CREATEDOWNLOAD = null;

		/// <summary>
		/// DownloadService���캯��
		/// </summary>
		public DownloadService( ParameterizedThreadStart D_CreateDownload )
		{
			D_CREATEDOWNLOAD = D_CreateDownload;
		}

		/// <summary>
		/// ��ʼ�����ط���
		/// </summary>
		public void Initialize()
		{
		}

		/// <summary>
		/// ���浱ǰ�����б�
		/// </summary>
		public void Save()
		{
		}

		/// <summary>
		/// ���һ��������
		/// </summary>
		/// <param name="oItem">��������</param>
		public void Add( Object oItem )
		{
			// �����б�
			DownloadItem di = new DownloadItem();
			di.DownloadInfomation = oItem;
			m_aItems.Add(di);

			// ����״̬�߳�
			if (m_aStatusThread == null || !m_aStatusThread.IsAlive)
			{
				m_aStatusThread = new Thread(new ThreadStart(StatusThread));
				m_aStatusThread.Priority = System.Threading.ThreadPriority.BelowNormal;
				m_aStatusThread.Start();
			}
		}

		/// <summary>
		/// ɾ��������
		/// </summary>
		/// <param name="oItem">��������</param>
		public void Remove( Object oItem )
		{
			// ɾ��ָ����
			for (int i = 0; i < m_aItems.Count; i++)
			{
				DownloadItem di = (DownloadItem)m_aItems[i];
				if (di.DownloadInfomation == oItem)
				{
					if (di.DownloadThread != null && di.DownloadThread.IsAlive)
						di.DownloadThread.Abort();
				}
				m_aItems.Remove(di);
			}

			// 
			if (m_aItems.Count == 0)
			{
				if (m_aStatusThread != null && m_aStatusThread.IsAlive)
				{
					m_aStatusThread.Abort();
					m_aStatusThread = null;
				}
			}
		}

		/// <summary>
		/// ����б��е�״̬�������µ�ǰ������
		/// </summary>
		private void StatusThread()
		{
			int nLiveThread = 0;
			int nWaitThread = 0;
			ArrayList aThreads = new ArrayList();

			// ��鲢���µ�ǰ�б��������������״̬
			for (int i = 0; i < m_aItems.Count; i++)
			{
				DownloadItem di = (DownloadItem)m_aItems[i];
				if (di.DownloadThread == null)
				{
					if (di.Status == DownloadStatus.Ready && nWaitThread < THREAD_MAXCOUNT)
					{
						aThreads.Add(di);
						nWaitThread++;
					}
				}
				else
				{
					if (di.DownloadThread.IsAlive)
					{
						nLiveThread++;
					}
					else
					{
						if (di.DownloadThread.ThreadState != ThreadState.Suspended)
						{
							di.DownloadThread.Abort();
							di.DownloadThread = null;
						}
						di.Status = DownloadStatus.Stop;
					}

				}

			}
		
			// ����п�λ,�򴴽��µ��߳�
			for (int i = 0; i < THREAD_MAXCOUNT - nLiveThread && i < nWaitThread; i++)
			{
				DownloadItem di = (DownloadItem)aThreads[i];
				di.DownloadThread = new Thread(D_CREATEDOWNLOAD);
				di.Status = DownloadStatus.Downloading;
				di.DownloadThread.Start( di.DownloadInfomation );
			}
		}
	}
}
