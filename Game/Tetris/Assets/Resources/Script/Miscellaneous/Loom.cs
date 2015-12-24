using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading;
using System.Linq;

public class Loom : MonoBehaviour
{
    /// <summary>
    ///  延迟在主线程执行的操作，分为两种，一种无延迟，另一种有延迟action
    /// </summary>
    public struct DelayedQueueItem
    {
        public float time;
        public Action action;
    }

    private List<DelayedQueueItem> _delayed = new  List<DelayedQueueItem>();
    private List<Action>           _actions = new List<Action>();


    /// <summary>
    /// 正在执行线程的最大数量，超过后要等待之前线程执行完毕，才会开启新线程
    /// </summary>
    public static int maxThreads = 4;
    static        int numThreads;
    
    private static Loom _current;
    private int         _count;

    /// <summary>
    /// 保证只有一个总控实例
    /// </summary>
    public static Loom Current
    {
        get
        {
            return _current;
        }
    }
    
    void Awake()
    {
        _current = this;
    }

    /// <summary>
    /// 提供给外部新建线程接口
    /// </summary>
    public static Thread RunAsync(Action a)
    {
        while(numThreads >= maxThreads)
        {
            Thread.Sleep(1);
        }
        Interlocked.Increment(ref numThreads);
        ThreadPool.QueueUserWorkItem(RunAction, a);
        return null;
    }

    /// <summary>
    /// Action的委托对象，action执行在此处调用
    /// </summary>
    private static void RunAction(object action)
    {
        try
        {
            ((Action)action)();
        }
        catch
        {
        }
        finally
        {
            Interlocked.Decrement(ref numThreads);
        }
        
    }

    /// <summary>
    /// 处理想要在主线程执行的操作
    /// </summary>
    public static void QueueOnMainThread(Action action)
    {
        QueueOnMainThread( action, 0f);
    }
    
    public static void QueueOnMainThread(Action action, float time)
    {
        if(time != 0)
        {
            lock(Current._delayed)
            {
                Current._delayed.Add(new DelayedQueueItem{ time = Time.time + time, action = action});
            }
        }
        else
        {
            lock (Current._actions)
            {
                Current._actions.Add(action);
            }
        }
    }
    
    
    void OnDisable()
    {
        if (_current == this)
        {
            
            _current = null;
        }
    }
    
    /// <summary>
    /// 本帧需要主线程执行操作。
    /// </summary>
    List<Action>           _currentActions = new List<Action>();
    List<DelayedQueueItem> _currentDelayed = new List<DelayedQueueItem>();

    /// <summary>
    /// 想要在主线程完成的操作但无法运行在子线程，那么久先加入队列，然后在此处延迟执行。
    /// 每次update，执行掉所有操作，并清空
    /// </summary>
    void Update()
    {
        lock (_actions)
        {
            _currentActions.Clear();
            _currentActions.AddRange(_actions);
            _actions.Clear();
        }
        foreach(var a in _currentActions)
        {
            a();
        }

        lock(_delayed)
        {
            _currentDelayed.Clear();
            _currentDelayed.AddRange(_delayed.Where(d=>d.time <= Time.time));
            foreach(var item in _currentDelayed)
                _delayed.Remove(item);
        }

        foreach(var delayed in _currentDelayed)
        {
            delayed.action();
        }
    }
}
