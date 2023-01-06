using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using NetBlog.Core.Utilities.Interceptors;
using NetBlog.Core.Utilities.IoC;
using System.Diagnostics;

namespace NetBlog.Core.Aspects.Performance
{
    public class PerformanceAspect : MethodInterception
    {
        private int _interval;
        private Stopwatch _stopwatch;

        public PerformanceAspect()
        {
            _interval = 3;
            _stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
        }
        public PerformanceAspect(int interval)
        {
            _interval = interval;
            _stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            _stopwatch.Start();
        }

        protected override void OnAfter(IInvocation invocation)
        {
            _stopwatch.Stop();
            double seconds = _stopwatch.Elapsed.TotalSeconds;
            if (seconds > _interval)
            {
                throw new Exception("Performans problemi bulunmaktadır.");
            }
            _stopwatch.Reset();
        }

    }
}
