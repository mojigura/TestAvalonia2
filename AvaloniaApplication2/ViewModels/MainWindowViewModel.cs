using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using Avalonia.Controls;
using Avalonia.Media;
using AvaloniaApplication2.Views;
using ReactiveUI;
using SkiaSharp;

namespace AvaloniaApplication2.ViewModels
{
    public class MyObject
    {
        public TestPopupWindow? testPopupWindow = null;
        public TestPopupWindowViewModel? testPopupWindowViewModel = null;
        public string strLogMessage = string.Empty;
     

        public MyObject()
        {
            try
            {
                testPopupWindow = new TestPopupWindow();
                testPopupWindowViewModel = testPopupWindow?.DataContext as TestPopupWindowViewModel;
            }
            catch (Exception e0)
            {
                StringBuilder msg0 = new StringBuilder();
                msg0.AppendFormat("Error!!\r\n");
                msg0.AppendFormat("An exception ({0}) occurred.\r\n", e0.GetType().Name);
                msg0.AppendFormat("   Message:\r\n{0}\r\n", e0.Message);
                msg0.AppendFormat("   Stack Trace:\r\n   {0}", e0.StackTrace);

                strLogMessage += msg0 + Environment.NewLine;
            }

        }

    }
    public class MainWindowViewModel : ViewModelBase
    {
        public Button? Button_StartTest = null;
        public Button? Button_StopTest = null;
        public Button? Button_LogClear = null;

        private MainWindow? mainWindow = null;

        private bool bLoopThreadTestProc = false;
        private Thread? threadTestProc = null;
        public Int64 n64MakeWindowCount = 0;
        public Int64 n64DeleteWindowCount = 0;
        public int nMakeWindowNum = 25;


        private ObservableCollection<MyObject>? listMyObjects = null;


        private string _StringTestMessage0_1 = "";
        public string StringTestMessage0_1
        {
            get
            {
                return _StringTestMessage0_1;
            }

            set
            {
                this.RaiseAndSetIfChanged(ref _StringTestMessage0_1, value);
            }
        }
        private string _StringTestMessage0_2 = "";
        public string StringTestMessage0_2
        {
            get
            {
                return _StringTestMessage0_2;
            }

            set
            {
                this.RaiseAndSetIfChanged(ref _StringTestMessage0_2, value);
            }
        }



        private string _StringTestMessage1 = "";
        public string StringTestMessage1
        {
            get
            {
                return _StringTestMessage1;
            }

            set
            {
                this.RaiseAndSetIfChanged(ref _StringTestMessage1, value);
            }
        }




        public void Init(MainWindow? mainWindow)
        {
            if (mainWindow != null)
            {
                this.mainWindow = mainWindow;

                Button_StartTest = mainWindow.Find<Button>("Button_StartTest");
                Button_StartTest.Command = ReactiveCommand.Create(OnClickCommand_StartTest);

                Button_StopTest = mainWindow.Find<Button>("Button_StopTest");
                Button_StopTest.Command = ReactiveCommand.Create(OnClickCommand_StopTest);

                Button_LogClear = mainWindow.Find<Button>("Button_LogClear");
                Button_LogClear.Command = ReactiveCommand.Create(OnClickCommand_LogClear);


                mainWindow.Closing += MainWindow_OnClosing;
            }
        }

       

        private void MainWindow_OnClosing(object? sender, CancelEventArgs e)
        {
            OnStopTest();
        }

        private void TestThreadProc()
        {
            try
            {
                DateTime dateNow = DateTime.Now;
 
                StringTestMessage1 += "TestThreadProc Start!" + Environment.NewLine;

                while (bLoopThreadTestProc)
                {
                    if (DateTime.Now - dateNow >= TimeSpan.FromMilliseconds(1000))
                    {
                        MyObject? obj0 = null;
                        Avalonia.Threading.Dispatcher.UIThread.Post(() =>
                        {
                            if (listMyObjects != null)
                            {
                                int nCount = listMyObjects.Count;
                                foreach (var item0 in listMyObjects)
                                {
                                    item0.testPopupWindow?.Close();

                                    item0.testPopupWindow = null;
                                    item0.testPopupWindowViewModel = null;
                                }

                                listMyObjects.Clear();
                                listMyObjects = null;

                                n64DeleteWindowCount += nCount;

                                StringTestMessage0_2 =
                                    string.Format("Delete {0} Window(s)", n64DeleteWindowCount);
                            }

                            listMyObjects = null;

                            listMyObjects = new ObservableCollection<MyObject>();

                            for (int i = 0; i < nMakeWindowNum; i++)
                            {
                                try
                                {
                                    obj0 = new MyObject();

                                }
                                catch (Exception e0)
                                {
                                    StringBuilder msg0 = new StringBuilder();
                                    msg0.AppendFormat("MFlowBControl Error!!\r\n");
                                    msg0.AppendFormat("An exception ({0}) occurred.\r\n", e0.GetType().Name);
                                    msg0.AppendFormat("   Message:\r\n{0}\r\n", e0.Message);
                                    msg0.AppendFormat("   Stack Trace:\r\n   {0}", e0.StackTrace);

                                    StringTestMessage1 += msg0 + Environment.NewLine;
                                }

                               

                                if (obj0 != null)
                                {
                                    if (obj0.strLogMessage != "")
                                    {
                                        StringTestMessage1 += obj0.strLogMessage + Environment.NewLine;
                                        obj0.strLogMessage = "";
                                    }

                                    listMyObjects.Add(obj0);
                                }
                            }

                            n64MakeWindowCount += listMyObjects.Count;





                            if (listMyObjects != null)
                            {
                                int nCount = listMyObjects.Count;
                                foreach (var item0 in listMyObjects)
                                {
                                    item0.testPopupWindow?.Close();

                                    item0.testPopupWindow = null;
                                    item0.testPopupWindowViewModel = null;
                                }

                                listMyObjects.Clear();
                                listMyObjects = null;

                                n64DeleteWindowCount += nCount;

                                StringTestMessage0_2 =
                                    string.Format("Delete {0} Window(s)", n64DeleteWindowCount);
                            }

                            listMyObjects = null;

                            listMyObjects = new ObservableCollection<MyObject>();

                            for (int i = 0; i < nMakeWindowNum; i++)
                            {
                                try
                                {
                                    obj0 = new MyObject();

                                }
                                catch (Exception e0)
                                {
                                    StringBuilder msg0 = new StringBuilder();
                                    msg0.AppendFormat("MFlowBControl Error!!\r\n");
                                    msg0.AppendFormat("An exception ({0}) occurred.\r\n", e0.GetType().Name);
                                    msg0.AppendFormat("   Message:\r\n{0}\r\n", e0.Message);
                                    msg0.AppendFormat("   Stack Trace:\r\n   {0}", e0.StackTrace);

                                    StringTestMessage1 += msg0 + Environment.NewLine;
                                }



                                if (obj0 != null)
                                {
                                    if (obj0.strLogMessage != "")
                                    {
                                        StringTestMessage1 += obj0.strLogMessage + Environment.NewLine;
                                        obj0.strLogMessage = "";
                                    }

                                    listMyObjects.Add(obj0);
                                }
                            }

                            n64MakeWindowCount += listMyObjects.Count;


                            StringTestMessage0_1 = string.Format("Make {0} Window(s)", n64MakeWindowCount);
                            
                            dateNow = DateTime.Now;
                        }, Avalonia.Threading.DispatcherPriority.Normal);
                   
                      
                    }

                    Thread.Yield();
                    Thread.Sleep(50);
                    Thread.Yield();
                }
            }
            catch (ThreadInterruptedException e)
            {
                //return;
            }
        }

        private void OnClickCommand_LogClear()
        {
            StringTestMessage1 = "";
        }



        private void OnStopTest()
        {
            if (bLoopThreadTestProc && threadTestProc != null)
            {
                bLoopThreadTestProc = false;
                threadTestProc?.Join(1000);
                if (threadTestProc is { IsAlive: true })
                {
                    threadTestProc.Interrupt();
                }
                threadTestProc = null;
            }
        }

       
        private void OnClickCommand_StartTest()
        {
            if (!bLoopThreadTestProc && threadTestProc == null)
            {
                threadTestProc = new Thread(TestThreadProc)
                {
                    Priority = ThreadPriority.Highest,
                    IsBackground = true
                };

                bLoopThreadTestProc = true;
                threadTestProc.Start();
            }
        }

        private void OnClickCommand_StopTest()
        {
            OnStopTest();
        }
    }
}