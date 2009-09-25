using System;
using System.Collections;
using System.Threading;

namespace BookStarToy
{
	/// <summary>创建下载线程的代理</summary>
	public delegate Thread CreateDownload( Object o );

	enum DownloadStatus
	{
		Ready,
		Downloading,
		Stop
	}

	class DownloadItem
	{
		/// <summary>下载项对象</summary>
		public Object		DownloadInfomation = null;

		/// <summary>下载线程</summary>
		public Thread		DownloadThread = null;

		/// <summary>下载项状态</summary>
		public DownloadStatus	Status = DownloadStatus.Ready;
	}

	/// <summary>
	/// DownloadService 的摘要说明。
	/// </summary>
	public class DownloadService
	{
		/// <summary>最大当前激活线程数</summary>
		const int THREAD_MAXCOUNT = 10;

		/// <summary>下载项列表</summary>
		protected ArrayList		m_aItems = new ArrayList();

		/// <summary>检查下载状态线程</summary>
		protected Thread		m_aStatusThread = null;

		/// <summary>创建下载线程的代理实例</summary>
		protected ParameterizedThreadStart	D_CREATEDOWNLOAD = null;

		/// <summary>
		/// DownloadService构造函数
		/// </summary>
		public DownloadService( ParameterizedThreadStart D_CreateDownload )
		{
			D_CREATEDOWNLOAD = D_CreateDownload;
		}

		/// <summary>
		/// 初始化下载服务
		/// </summary>
		public void Initialize()
		{
		}

		/// <summary>
		/// 保存当前下载列表
		/// </summary>
		public void Save()
		{
		}

		/// <summary>
		/// 添加一个下载项
		/// </summary>
		/// <param name="oItem">下载项句柄</param>
		public void Add( Object oItem )
		{
			// 加入列表
			DownloadItem di = new DownloadItem();
			di.DownloadInfomation = oItem;
			m_aItems.Add(di);

			// 激活状态线程
			if (m_aStatusThread == null || !m_aStatusThread.IsAlive)
			{
				m_aStatusThread = new Thread(new ThreadStart(StatusThread));
				m_aStatusThread.Priority = System.Threading.ThreadPriority.BelowNormal;
				m_aStatusThread.Start();
			}
		}

		/// <summary>
		/// 删除下载项
		/// </summary>
		/// <param name="oItem">下载项句柄</param>
		public void Remove( Object oItem )
		{
			// 删除指定项
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
		/// 检查列表中的状态，并更新当前下载项
		/// </summary>
		private void StatusThread()
		{
			int nLiveThread = 0;
			int nWaitThread = 0;
			ArrayList aThreads = new ArrayList();

			// 检查并更新当前列表中所有下载项的状态
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
		
			// 如果有空位,则创建新的线程
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
