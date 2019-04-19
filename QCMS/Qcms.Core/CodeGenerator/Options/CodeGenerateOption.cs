
using System;
using System.Collections.Generic;
using System.Text;

namespace Qcms.Core.CodeGenerator.Options
{
    /// <summary>
    /// 代码生成选项
    /// </summary>
    public class CodeGenerateOption : DbOption
    {

        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// 代码生成时间
        /// </summary>
        public string GeneratorTime { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        /// <summary>
        /// 输出路径
        /// </summary>
        public string OutputPath { get; set; }

        /// <summary>
        /// 实体命名空间
        /// </summary>
        public string ModelsNamespace { get; set; }
        /// <summary>
        /// 仓储接口命名空间
        /// </summary>
        public string IRepositoryNamespace { get; set; }
        /// <summary>
        /// 仓储命名空间
        /// </summary>
        public string RepositoryNamespace { get; set; }
        /// <summary>
        /// 服务接口命名空间
        /// </summary>
        public string IServicesNamespace { get; set; }
        /// <summary>
        /// 服务命名空间
        /// </summary>
        public string ServicesNamespace { get; set; }
        /// <summary>
        /// dto 层命名空间
        /// </summary>
        public string DtosNamespace { get; set; }
        /// <summary>
        /// 控制层命名空间
        /// </summary>
        public string ControllerNamespace { get; set; }
        /// <summary>
        /// 是否开启自动生成仓储接口层
        /// </summary>
        public bool IsUseGenerateIRepository { get; set; }

        /// <summary>
        /// 是否开启自动生成仓储层
        /// </summary>
        public bool IsUseGenerateRepository { get; set; }
        /// <summary>
        /// 是否开启自动生成模型层
        /// </summary>
        public bool IsUseGenerateModels { get; set; }
        /// <summary>
        /// 是否开启自动服务接口层
        /// </summary>
        public bool IsUseGenerateIServices { get; set; }
        /// <summary>
        /// 是否启动服务层
        /// </summary>
        public bool IsUseGenerateServices { get; set; }
        /// <summary>
        /// 是否开启生成dtos
        /// </summary>
        public bool IsUseGenerateDtos { get; set; }
        /// <summary>
        /// 是否开启生成controller
        /// </summary>
        public bool IsUseGenerateController { get; set; }
        /// <summary>
        /// 开启自动生成仓储接口层
        /// </summary>
        /// <param name="IRepositoryNamespace"></param>
        /// <param name="isUseGenerateIRepository"></param>
        public void UseGenerateIRepository(string iRepositoryNamespace, bool isUseGenerateIRepository = true) {
            this.IRepositoryNamespace = iRepositoryNamespace;
            this.IsUseGenerateIRepository = isUseGenerateIRepository;
        }
        /// <summary>
        /// 开启自动生成仓储层
        /// </summary>
        /// <param name="repositoryNamespace"></param>
        /// <param name="isUseGenerateRepository"></param>
        public void UseGenerateRepository(string repositoryNamespace, bool isUseGenerateRepository = true)
        {
            this.RepositoryNamespace = repositoryNamespace;
            this.IsUseGenerateRepository = isUseGenerateRepository;
        }
        /// <summary>
        /// 开启自动生成模型层
        /// </summary>
        /// <param name="modelsNamespace"></param>
        /// <param name="isUseGenerateModels"></param>
        public void UseGenerateModels(string modelsNamespace, bool isUseGenerateModels = true)
        {
            this.ModelsNamespace = modelsNamespace;
            this.IsUseGenerateModels = isUseGenerateModels;
        }
        /// <summary>
        /// 开启自动服务接口层
        /// </summary>
        /// <param name="iServicesNamespace"></param>
        /// <param name="isUseGenerateIServices"></param>
        public void UseGenerateIServices(string iServicesNamespace, bool isUseGenerateIServices = true)
        {
            this.IServicesNamespace = iServicesNamespace;
            this.IsUseGenerateIServices = isUseGenerateIServices;
        }
        /// <summary>
        /// 启动生成服务层模块code
        /// </summary>
        /// <param name="servicesNamespace"></param>
        /// <param name="isUseGenerateServices"></param>
        public void UseGenerateServices(string servicesNamespace, bool isUseGenerateServices = true) {

            this.ServicesNamespace = servicesNamespace;
            this.IsUseGenerateIServices = isUseGenerateServices;
        }
        /// <summary>
        /// 启动生成dtos模板数据
        /// </summary>
        /// <param name="dtosNamespace"></param>
        /// <param name="isUseGenerateDtos"></param>
        public void UseGenerateDtos(string dtosNamespace, bool isUseGenerateDtos = true) {
            this.DtosNamespace = dtosNamespace;
            this.IsUseGenerateDtos = isUseGenerateDtos;
        }
        /// <summary>
        /// 开启生成controller
        /// </summary>
        /// <param name="controllerNamespace"></param>
        /// <param name="isUseGenerateController"></param>
        public void UseGenerateController(string controllerNamespace, bool isUseGenerateController = true)
        {
            this.ControllerNamespace = controllerNamespace;
            this.IsUseGenerateController = isUseGenerateController;
        }
    }
}
