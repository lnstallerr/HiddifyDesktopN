﻿using v2rayN;
using Newtonsoft;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using System.Net;
using Newtonsoft.Json;
using System.Windows.Navigation;

namespace HiddifyN.Tool
{
    public class TestSpeed
    {
        private string _appHttpProxy;
        public TestSpeed()
        {
            WebProxy p = (WebProxy)Utils.GetAppProxyAddress();
            _appHttpProxy = p.Address.OriginalString;
        }

        public double? UploadSpeed(bool withProxy = true)
        {
            var sInfo = new ProcessStartInfo();
            var extra = withProxy ? $"--http-proxy={_appHttpProxy}" : "";
            sInfo = new ProcessStartInfo()
            {
                FileName = Global.SpeedTestProgramExePath,
                Arguments = $"--no-download --no-icmp --json {extra}",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
            };
            

            // Start speed tester program and get its output or error and handle it
            var (stdout, stderr) = Utils.StartProcess(sInfo);
            if (stdout == null)
            {
                return null;
            }
            // Parse json result
            dynamic testerResult = JObject.Parse(ConvertJsonListToObject(stdout.Trim()));

            // Get download speed as Mbps
            double uploadSpeed = testerResult.upload;

            return uploadSpeed;

        }
        public double? DownloadSpeed(bool withProxy = true)
        {
            var sInfo = new ProcessStartInfo();
            var extra = withProxy ? $"--http-proxy={_appHttpProxy}" : "";
            sInfo = new ProcessStartInfo()
            {
                FileName = Global.SpeedTestProgramExePath,
                Arguments = $"--no-upload --no-icmp --json {extra}",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
            };
            

            // Start speed tester program and get its output or error and handle it
            var (stdout, stderr) = Utils.StartProcess(sInfo);
            if (stdout == null)
            {
                return null;
            }
            // Parse json result
            dynamic testerResult = JObject.Parse(ConvertJsonListToObject(stdout.Trim()));

            // Get download speed as Mbps
            double downloadSpeed = testerResult.download;

            return downloadSpeed;
        }

        private string ConvertJsonListToObject(string j)
        {
            return j.Remove(j.Length- 1,1).Remove(0,1).Trim();
        }
    }
}
