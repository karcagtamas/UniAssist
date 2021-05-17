using System;
using System.IO;
using System.Linq;
using UniAssist.Database;
using UniAssist.Entities;
using UniAssist.Models;
using File = System.IO.File;

namespace UniAssist.Services
{
    /// <summary>
    /// Period Service
    /// </summary>
    public class PeriodService : DatabaseService<Period>, IPeriodService
    {
        private readonly IConfigService _configService;

        /// <summary>
        /// Initialize Period Service
        /// </summary>
        /// <param name="context">Database Context</param>
        /// <param name="configService">Config Service</param>
        public PeriodService(ApplicationDbContext context, IConfigService configService) : base(context)
        {
            _configService = configService;
        }

        /// <inheritdoc />
        public override void Add(Period value)
        {
            this.CreatePeriodFolder(value);
            base.Add(value);
        }

        /// <inheritdoc />
        public override void Update(Period value)
        {
            var old = this.Context.Periods.Find(value.Id);
            this.UpdatePeriodFolderName(value, old.FolderName);
            base.Update(value);
        }

        /// <inheritdoc />
        public override void Delete(Period value)
        {
            this.DeletePeriodFolder(value);
            base.Delete(value);
        }

        /// <inheritdoc />
        public void CreatePeriodFolder(Period period)
        {
            string path = this.GetPath(period.FolderName);
            if (Directory.Exists(path))
            {
                Directory.Delete(path);
            }

            Directory.CreateDirectory($"{this._configService.GetWorkingDirectory()}/{period.FolderName}");
            File.WriteAllLines($"{path}/key.data", new[] {period.Id});
        }

        /// <inheritdoc />
        public void UpdatePeriodFolderName(Period period, string oldName)
        {
            string oldPath = this.GetPath(oldName);
            string newPath = this.GetPath(period.FolderName);

            if (oldPath == newPath)
            {
                return;
            }

            if (!Directory.Exists(oldPath) || Directory.Exists(newPath))
            {
                return;
            }

            Directory.Move(oldPath, newPath);
        }

        /// <inheritdoc />
        public void DeletePeriodFolder(Period period)
        {
            string path = this.GetPath(period.FolderName);

            if (Directory.Exists(path))
            {
                Directory.Delete(path);
            }
        }

        /// <inheritdoc />
        public PeriodSyncResult Sync()
        {
            var list = this.GetAll().ToList();

            foreach (var i in list)
            {
                var path = this.GetPath(i.FolderName);
            }

            return new PeriodSyncResult();
        }

        private string GetPath(string folderName)
        {
            return $"{this._configService.GetWorkingDirectory()}/{folderName}";
        }
    }
}