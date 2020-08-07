// ==========================================================================================
// Desarrollado Por		    :   AlbatrosSoft Dev
// Fecha de Creación		:   2016/10/16
// Producto o sistema	    :   AlbatrosSoft.PetMap
// Empresa			        :   AlbatrosSoft
// Proyecto			        :   PetMap10
// ==========================================================================================
// Versión	        Descripción
// 1.0.0.0	        Controla todas las operaciones de persistencia hacia el origen de datos 
//                  de la aplicación (Código generado automáticamente).
//             
// ==========================================================================================
// HISTORIAL DE CAMBIOS:
// ==========================================================================================
// Ver.	 Fecha		    Autor					Descripción
// ---	 -------------	----------------------	----------------------------------------------
// XX	 yyyy/MM/dd	    [Nombre Completo]	    [Razón del cambio realizado] 
// ==========================================================================================

using System;
using System.Collections.Generic;
using System.Linq;

namespace AlbatrosSoft.PetMap.Data.Repository
{
    /// <summary>
    /// Establece un punto de acceso comun a las clases que prestan servicios de persistencia hacia el 
    /// origen de datos de la aplicación.
    /// </summary>
    public class NaviUnitOfWork
    {
    	#region Singleton Instance
    	[ThreadStatic]
    	private static NaviUnitOfWork _Instance;
            
    	public static NaviUnitOfWork Instance        
        {
            get
            {
                if (NoInstance)
                {
                    CreateInstance();
                }
                return _Instance;
            }
        }
    
        private static void CreateInstance()
        {            
    		_Instance = new NaviUnitOfWork();
        }
    
        private static bool NoInstance
        {
            get
            {
                return _Instance == null;
            }
        }
    
        private NaviUnitOfWork()
        {
    
        }
    	#endregion Singleton Instance
    
        private AppUserRepository _AppUserRepository;
    
    	/// <summary>
        /// Servicio que expone las operaciones de persistencia hacia el origen de datos para la entidad de dominio AppUser.
        /// </summary>
        public AppUserRepository AppUserRepository
        {
            get
            {
                if (this._AppUserRepository == null)
                {
                    this._AppUserRepository = new AppUserRepository();
                }
                return this._AppUserRepository;
            }
        }
    
        private AppUserRoleRepository _AppUserRoleRepository;
    
    	/// <summary>
        /// Servicio que expone las operaciones de persistencia hacia el origen de datos para la entidad de dominio AppUserRole.
        /// </summary>
        public AppUserRoleRepository AppUserRoleRepository
        {
            get
            {
                if (this._AppUserRoleRepository == null)
                {
                    this._AppUserRoleRepository = new AppUserRoleRepository();
                }
                return this._AppUserRoleRepository;
            }
        }
    
        private ContactRepository _ContactRepository;
    
    	/// <summary>
        /// Servicio que expone las operaciones de persistencia hacia el origen de datos para la entidad de dominio Contact.
        /// </summary>
        public ContactRepository ContactRepository
        {
            get
            {
                if (this._ContactRepository == null)
                {
                    this._ContactRepository = new ContactRepository();
                }
                return this._ContactRepository;
            }
        }
    
        private ContactTypeRepository _ContactTypeRepository;
    
    	/// <summary>
        /// Servicio que expone las operaciones de persistencia hacia el origen de datos para la entidad de dominio ContactType.
        /// </summary>
        public ContactTypeRepository ContactTypeRepository
        {
            get
            {
                if (this._ContactTypeRepository == null)
                {
                    this._ContactTypeRepository = new ContactTypeRepository();
                }
                return this._ContactTypeRepository;
            }
        }
    
        private CustomerRepository _CustomerRepository;
    
    	/// <summary>
        /// Servicio que expone las operaciones de persistencia hacia el origen de datos para la entidad de dominio Customer.
        /// </summary>
        public CustomerRepository CustomerRepository
        {
            get
            {
                if (this._CustomerRepository == null)
                {
                    this._CustomerRepository = new CustomerRepository();
                }
                return this._CustomerRepository;
            }
        }
    
        private CustomerBillingStatusRepository _CustomerBillingStatusRepository;
    
    	/// <summary>
        /// Servicio que expone las operaciones de persistencia hacia el origen de datos para la entidad de dominio CustomerBillingStatus.
        /// </summary>
        public CustomerBillingStatusRepository CustomerBillingStatusRepository
        {
            get
            {
                if (this._CustomerBillingStatusRepository == null)
                {
                    this._CustomerBillingStatusRepository = new CustomerBillingStatusRepository();
                }
                return this._CustomerBillingStatusRepository;
            }
        }
    
        private DealerRepository _DealerRepository;
    
    	/// <summary>
        /// Servicio que expone las operaciones de persistencia hacia el origen de datos para la entidad de dominio Dealer.
        /// </summary>
        public DealerRepository DealerRepository
        {
            get
            {
                if (this._DealerRepository == null)
                {
                    this._DealerRepository = new DealerRepository();
                }
                return this._DealerRepository;
            }
        }
    
        private IdentificationTypeRepository _IdentificationTypeRepository;
    
    	/// <summary>
        /// Servicio que expone las operaciones de persistencia hacia el origen de datos para la entidad de dominio IdentificationType.
        /// </summary>
        public IdentificationTypeRepository IdentificationTypeRepository
        {
            get
            {
                if (this._IdentificationTypeRepository == null)
                {
                    this._IdentificationTypeRepository = new IdentificationTypeRepository();
                }
                return this._IdentificationTypeRepository;
            }
        }
    
    }
}
