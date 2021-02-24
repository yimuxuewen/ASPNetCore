﻿using Consul;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceInstance
{
    public static class ConsulHelper
    {
        public static void ConsulRegist(this IConfiguration configuration)
        {
            //创建Consul客户端
            ConsulClient client = new ConsulClient(c => {
                c.Address = new Uri("http://127.0.0.1:8500/");
                c.Datacenter = "dc1";
            });
            //重命令行中获取 ip port weight(权重) 目的是重复反向代理
            string ip = configuration["ip"];
            int port = int.Parse(configuration["port"]);
            //当为空时权重为 10
            int weight = string.IsNullOrWhiteSpace(configuration["weight"]) ? 1 : int.Parse(configuration["weight"]);
            client.Agent.ServiceRegister(new AgentServiceRegistration()
            {
                ID = "service" + Guid.NewGuid(),//唯一的
                Name = "UserInfoService",//服务组名称
                Address = ip,//ip需要改动
                Port = port,//不同实例
                Tags = new string[] { weight.ToString() }, //权重设置
                Check = new AgentServiceCheck() //健康检测
                {
                    Interval = TimeSpan.FromSeconds(10), //每隔多久检测一次
                    HTTP = $"http://{ip}:{port}/api/Health/Index", //检测地址
                    Timeout = TimeSpan.FromSeconds(5), //多少秒为超时
                    DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(60) //在遇到异常后关闭自身服务通道,最短60s，小于60s不可移除
                }
            });
            Console.WriteLine($"{ip}:{port} weight:{weight}");
        }
    }
}
