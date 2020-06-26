﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AccesoDatos
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="dbproyectolenguajes")]
	public partial class DataClasses1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Definiciones de métodos de extensibilidad
    partial void OnCreated();
    partial void InsertEstadoPedido(EstadoPedido instance);
    partial void UpdateEstadoPedido(EstadoPedido instance);
    partial void DeleteEstadoPedido(EstadoPedido instance);
    partial void InsertPedido(Pedido instance);
    partial void UpdatePedido(Pedido instance);
    partial void DeletePedido(Pedido instance);
    partial void InsertTipoUsuario(TipoUsuario instance);
    partial void UpdateTipoUsuario(TipoUsuario instance);
    partial void DeleteTipoUsuario(TipoUsuario instance);
    partial void InsertUsuario(Usuario instance);
    partial void UpdateUsuario(Usuario instance);
    partial void DeleteUsuario(Usuario instance);
    partial void InsertPlato(Plato instance);
    partial void UpdatePlato(Plato instance);
    partial void DeletePlato(Plato instance);
    #endregion
		
		public DataClasses1DataContext() : 
				base(global::AccesoDatos.Properties.Settings.Default.dbproyectolenguajesConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<EstadoPedido> EstadoPedido
		{
			get
			{
				return this.GetTable<EstadoPedido>();
			}
		}
		
		public System.Data.Linq.Table<Pedido> Pedido
		{
			get
			{
				return this.GetTable<Pedido>();
			}
		}
		
		public System.Data.Linq.Table<Pedido_X_Plato> Pedido_X_Plato
		{
			get
			{
				return this.GetTable<Pedido_X_Plato>();
			}
		}
		
		public System.Data.Linq.Table<TipoUsuario> TipoUsuario
		{
			get
			{
				return this.GetTable<TipoUsuario>();
			}
		}
		
		public System.Data.Linq.Table<Usuario> Usuario
		{
			get
			{
				return this.GetTable<Usuario>();
			}
		}
		
		public System.Data.Linq.Table<Plato> Plato
		{
			get
			{
				return this.GetTable<Plato>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.EstadoPedido")]
	public partial class EstadoPedido : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private short _EstadoPedidoID;
		
		private string _DescEstadoPedido;
		
		private EntitySet<Pedido> _Pedido;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnEstadoPedidoIDChanging(short value);
    partial void OnEstadoPedidoIDChanged();
    partial void OnDescEstadoPedidoChanging(string value);
    partial void OnDescEstadoPedidoChanged();
    #endregion
		
		public EstadoPedido()
		{
			this._Pedido = new EntitySet<Pedido>(new Action<Pedido>(this.attach_Pedido), new Action<Pedido>(this.detach_Pedido));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EstadoPedidoID", AutoSync=AutoSync.OnInsert, DbType="SmallInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public short EstadoPedidoID
		{
			get
			{
				return this._EstadoPedidoID;
			}
			set
			{
				if ((this._EstadoPedidoID != value))
				{
					this.OnEstadoPedidoIDChanging(value);
					this.SendPropertyChanging();
					this._EstadoPedidoID = value;
					this.SendPropertyChanged("EstadoPedidoID");
					this.OnEstadoPedidoIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DescEstadoPedido", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string DescEstadoPedido
		{
			get
			{
				return this._DescEstadoPedido;
			}
			set
			{
				if ((this._DescEstadoPedido != value))
				{
					this.OnDescEstadoPedidoChanging(value);
					this.SendPropertyChanging();
					this._DescEstadoPedido = value;
					this.SendPropertyChanged("DescEstadoPedido");
					this.OnDescEstadoPedidoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="EstadoPedido_Pedido", Storage="_Pedido", ThisKey="EstadoPedidoID", OtherKey="EstadoPedidoID")]
		public EntitySet<Pedido> Pedido
		{
			get
			{
				return this._Pedido;
			}
			set
			{
				this._Pedido.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Pedido(Pedido entity)
		{
			this.SendPropertyChanging();
			entity.EstadoPedido = this;
		}
		
		private void detach_Pedido(Pedido entity)
		{
			this.SendPropertyChanging();
			entity.EstadoPedido = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Pedido")]
	public partial class Pedido : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private short _PedidoID;
		
		private System.DateTime _FechaPedido;
		
		private short _EstadoPedidoID;
		
		private short _UsuarioID;
		
		private EntityRef<EstadoPedido> _EstadoPedido;
		
		private EntityRef<Usuario> _Usuario;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnPedidoIDChanging(short value);
    partial void OnPedidoIDChanged();
    partial void OnFechaPedidoChanging(System.DateTime value);
    partial void OnFechaPedidoChanged();
    partial void OnEstadoPedidoIDChanging(short value);
    partial void OnEstadoPedidoIDChanged();
    partial void OnUsuarioIDChanging(short value);
    partial void OnUsuarioIDChanged();
    #endregion
		
		public Pedido()
		{
			this._EstadoPedido = default(EntityRef<EstadoPedido>);
			this._Usuario = default(EntityRef<Usuario>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PedidoID", AutoSync=AutoSync.OnInsert, DbType="SmallInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public short PedidoID
		{
			get
			{
				return this._PedidoID;
			}
			set
			{
				if ((this._PedidoID != value))
				{
					this.OnPedidoIDChanging(value);
					this.SendPropertyChanging();
					this._PedidoID = value;
					this.SendPropertyChanged("PedidoID");
					this.OnPedidoIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FechaPedido", DbType="DateTime NOT NULL")]
		public System.DateTime FechaPedido
		{
			get
			{
				return this._FechaPedido;
			}
			set
			{
				if ((this._FechaPedido != value))
				{
					this.OnFechaPedidoChanging(value);
					this.SendPropertyChanging();
					this._FechaPedido = value;
					this.SendPropertyChanged("FechaPedido");
					this.OnFechaPedidoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EstadoPedidoID", DbType="SmallInt NOT NULL")]
		public short EstadoPedidoID
		{
			get
			{
				return this._EstadoPedidoID;
			}
			set
			{
				if ((this._EstadoPedidoID != value))
				{
					if (this._EstadoPedido.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnEstadoPedidoIDChanging(value);
					this.SendPropertyChanging();
					this._EstadoPedidoID = value;
					this.SendPropertyChanged("EstadoPedidoID");
					this.OnEstadoPedidoIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UsuarioID", DbType="SmallInt NOT NULL")]
		public short UsuarioID
		{
			get
			{
				return this._UsuarioID;
			}
			set
			{
				if ((this._UsuarioID != value))
				{
					if (this._Usuario.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnUsuarioIDChanging(value);
					this.SendPropertyChanging();
					this._UsuarioID = value;
					this.SendPropertyChanged("UsuarioID");
					this.OnUsuarioIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="EstadoPedido_Pedido", Storage="_EstadoPedido", ThisKey="EstadoPedidoID", OtherKey="EstadoPedidoID", IsForeignKey=true)]
		public EstadoPedido EstadoPedido
		{
			get
			{
				return this._EstadoPedido.Entity;
			}
			set
			{
				EstadoPedido previousValue = this._EstadoPedido.Entity;
				if (((previousValue != value) 
							|| (this._EstadoPedido.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._EstadoPedido.Entity = null;
						previousValue.Pedido.Remove(this);
					}
					this._EstadoPedido.Entity = value;
					if ((value != null))
					{
						value.Pedido.Add(this);
						this._EstadoPedidoID = value.EstadoPedidoID;
					}
					else
					{
						this._EstadoPedidoID = default(short);
					}
					this.SendPropertyChanged("EstadoPedido");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Usuario_Pedido", Storage="_Usuario", ThisKey="UsuarioID", OtherKey="UsuarioID", IsForeignKey=true)]
		public Usuario Usuario
		{
			get
			{
				return this._Usuario.Entity;
			}
			set
			{
				Usuario previousValue = this._Usuario.Entity;
				if (((previousValue != value) 
							|| (this._Usuario.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Usuario.Entity = null;
						previousValue.Pedido.Remove(this);
					}
					this._Usuario.Entity = value;
					if ((value != null))
					{
						value.Pedido.Add(this);
						this._UsuarioID = value.UsuarioID;
					}
					else
					{
						this._UsuarioID = default(short);
					}
					this.SendPropertyChanged("Usuario");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Pedido_X_Plato")]
	public partial class Pedido_X_Plato
	{
		
		private short _PlatoID;
		
		private short _PedidoID;
		
		private short _CantidadPlato;
		
		public Pedido_X_Plato()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PlatoID", DbType="SmallInt NOT NULL")]
		public short PlatoID
		{
			get
			{
				return this._PlatoID;
			}
			set
			{
				if ((this._PlatoID != value))
				{
					this._PlatoID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PedidoID", DbType="SmallInt NOT NULL")]
		public short PedidoID
		{
			get
			{
				return this._PedidoID;
			}
			set
			{
				if ((this._PedidoID != value))
				{
					this._PedidoID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CantidadPlato", DbType="SmallInt NOT NULL")]
		public short CantidadPlato
		{
			get
			{
				return this._CantidadPlato;
			}
			set
			{
				if ((this._CantidadPlato != value))
				{
					this._CantidadPlato = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.TipoUsuario")]
	public partial class TipoUsuario : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private short _TipoUsuarioID;
		
		private string _DescTipoUsuario;
		
		private EntitySet<Usuario> _Usuario;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnTipoUsuarioIDChanging(short value);
    partial void OnTipoUsuarioIDChanged();
    partial void OnDescTipoUsuarioChanging(string value);
    partial void OnDescTipoUsuarioChanged();
    #endregion
		
		public TipoUsuario()
		{
			this._Usuario = new EntitySet<Usuario>(new Action<Usuario>(this.attach_Usuario), new Action<Usuario>(this.detach_Usuario));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TipoUsuarioID", AutoSync=AutoSync.OnInsert, DbType="SmallInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public short TipoUsuarioID
		{
			get
			{
				return this._TipoUsuarioID;
			}
			set
			{
				if ((this._TipoUsuarioID != value))
				{
					this.OnTipoUsuarioIDChanging(value);
					this.SendPropertyChanging();
					this._TipoUsuarioID = value;
					this.SendPropertyChanged("TipoUsuarioID");
					this.OnTipoUsuarioIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DescTipoUsuario", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string DescTipoUsuario
		{
			get
			{
				return this._DescTipoUsuario;
			}
			set
			{
				if ((this._DescTipoUsuario != value))
				{
					this.OnDescTipoUsuarioChanging(value);
					this.SendPropertyChanging();
					this._DescTipoUsuario = value;
					this.SendPropertyChanged("DescTipoUsuario");
					this.OnDescTipoUsuarioChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="TipoUsuario_Usuario", Storage="_Usuario", ThisKey="TipoUsuarioID", OtherKey="TipoUsuarioID")]
		public EntitySet<Usuario> Usuario
		{
			get
			{
				return this._Usuario;
			}
			set
			{
				this._Usuario.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Usuario(Usuario entity)
		{
			this.SendPropertyChanging();
			entity.TipoUsuario = this;
		}
		
		private void detach_Usuario(Usuario entity)
		{
			this.SendPropertyChanging();
			entity.TipoUsuario = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Usuario")]
	public partial class Usuario : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private short _UsuarioID;
		
		private string _CorreoElectronico;
		
		private string _NombreCompleto;
		
		private string _Contraseña;
		
		private bool _Bloqueado;
		
		private short _TipoUsuarioID;
		
		private string _DescUsuario;
		
		private bool _ActivoSN;
		
		private EntitySet<Pedido> _Pedido;
		
		private EntityRef<TipoUsuario> _TipoUsuario;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUsuarioIDChanging(short value);
    partial void OnUsuarioIDChanged();
    partial void OnCorreoElectronicoChanging(string value);
    partial void OnCorreoElectronicoChanged();
    partial void OnNombreCompletoChanging(string value);
    partial void OnNombreCompletoChanged();
    partial void OnContraseñaChanging(string value);
    partial void OnContraseñaChanged();
    partial void OnBloqueadoChanging(bool value);
    partial void OnBloqueadoChanged();
    partial void OnTipoUsuarioIDChanging(short value);
    partial void OnTipoUsuarioIDChanged();
    partial void OnDescUsuarioChanging(string value);
    partial void OnDescUsuarioChanged();
    partial void OnActivoSNChanging(bool value);
    partial void OnActivoSNChanged();
    #endregion
		
		public Usuario()
		{
			this._Pedido = new EntitySet<Pedido>(new Action<Pedido>(this.attach_Pedido), new Action<Pedido>(this.detach_Pedido));
			this._TipoUsuario = default(EntityRef<TipoUsuario>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UsuarioID", AutoSync=AutoSync.OnInsert, DbType="SmallInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public short UsuarioID
		{
			get
			{
				return this._UsuarioID;
			}
			set
			{
				if ((this._UsuarioID != value))
				{
					this.OnUsuarioIDChanging(value);
					this.SendPropertyChanging();
					this._UsuarioID = value;
					this.SendPropertyChanged("UsuarioID");
					this.OnUsuarioIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CorreoElectronico", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string CorreoElectronico
		{
			get
			{
				return this._CorreoElectronico;
			}
			set
			{
				if ((this._CorreoElectronico != value))
				{
					this.OnCorreoElectronicoChanging(value);
					this.SendPropertyChanging();
					this._CorreoElectronico = value;
					this.SendPropertyChanged("CorreoElectronico");
					this.OnCorreoElectronicoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NombreCompleto", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string NombreCompleto
		{
			get
			{
				return this._NombreCompleto;
			}
			set
			{
				if ((this._NombreCompleto != value))
				{
					this.OnNombreCompletoChanging(value);
					this.SendPropertyChanging();
					this._NombreCompleto = value;
					this.SendPropertyChanged("NombreCompleto");
					this.OnNombreCompletoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Contraseña", DbType="NVarChar(10) NOT NULL", CanBeNull=false)]
		public string Contraseña
		{
			get
			{
				return this._Contraseña;
			}
			set
			{
				if ((this._Contraseña != value))
				{
					this.OnContraseñaChanging(value);
					this.SendPropertyChanging();
					this._Contraseña = value;
					this.SendPropertyChanged("Contraseña");
					this.OnContraseñaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Bloqueado", DbType="Bit NOT NULL")]
		public bool Bloqueado
		{
			get
			{
				return this._Bloqueado;
			}
			set
			{
				if ((this._Bloqueado != value))
				{
					this.OnBloqueadoChanging(value);
					this.SendPropertyChanging();
					this._Bloqueado = value;
					this.SendPropertyChanged("Bloqueado");
					this.OnBloqueadoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TipoUsuarioID", DbType="SmallInt NOT NULL")]
		public short TipoUsuarioID
		{
			get
			{
				return this._TipoUsuarioID;
			}
			set
			{
				if ((this._TipoUsuarioID != value))
				{
					if (this._TipoUsuario.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnTipoUsuarioIDChanging(value);
					this.SendPropertyChanging();
					this._TipoUsuarioID = value;
					this.SendPropertyChanged("TipoUsuarioID");
					this.OnTipoUsuarioIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DescUsuario", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string DescUsuario
		{
			get
			{
				return this._DescUsuario;
			}
			set
			{
				if ((this._DescUsuario != value))
				{
					this.OnDescUsuarioChanging(value);
					this.SendPropertyChanging();
					this._DescUsuario = value;
					this.SendPropertyChanged("DescUsuario");
					this.OnDescUsuarioChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivoSN", DbType="Bit NOT NULL")]
		public bool ActivoSN
		{
			get
			{
				return this._ActivoSN;
			}
			set
			{
				if ((this._ActivoSN != value))
				{
					this.OnActivoSNChanging(value);
					this.SendPropertyChanging();
					this._ActivoSN = value;
					this.SendPropertyChanged("ActivoSN");
					this.OnActivoSNChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Usuario_Pedido", Storage="_Pedido", ThisKey="UsuarioID", OtherKey="UsuarioID")]
		public EntitySet<Pedido> Pedido
		{
			get
			{
				return this._Pedido;
			}
			set
			{
				this._Pedido.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="TipoUsuario_Usuario", Storage="_TipoUsuario", ThisKey="TipoUsuarioID", OtherKey="TipoUsuarioID", IsForeignKey=true)]
		public TipoUsuario TipoUsuario
		{
			get
			{
				return this._TipoUsuario.Entity;
			}
			set
			{
				TipoUsuario previousValue = this._TipoUsuario.Entity;
				if (((previousValue != value) 
							|| (this._TipoUsuario.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._TipoUsuario.Entity = null;
						previousValue.Usuario.Remove(this);
					}
					this._TipoUsuario.Entity = value;
					if ((value != null))
					{
						value.Usuario.Add(this);
						this._TipoUsuarioID = value.TipoUsuarioID;
					}
					else
					{
						this._TipoUsuarioID = default(short);
					}
					this.SendPropertyChanged("TipoUsuario");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Pedido(Pedido entity)
		{
			this.SendPropertyChanging();
			entity.Usuario = this;
		}
		
		private void detach_Pedido(Pedido entity)
		{
			this.SendPropertyChanging();
			entity.Usuario = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Plato")]
	public partial class Plato : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private short _PlatoID;
		
		private string _Nombre;
		
		private string _DescPlato;
		
		private decimal _Precio;
		
		private System.Data.Linq.Binary _Foto;
		
		private bool _Estado;
		
		private bool _ActivoSN;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnPlatoIDChanging(short value);
    partial void OnPlatoIDChanged();
    partial void OnNombreChanging(string value);
    partial void OnNombreChanged();
    partial void OnDescPlatoChanging(string value);
    partial void OnDescPlatoChanged();
    partial void OnPrecioChanging(decimal value);
    partial void OnPrecioChanged();
    partial void OnFotoChanging(System.Data.Linq.Binary value);
    partial void OnFotoChanged();
    partial void OnEstadoChanging(bool value);
    partial void OnEstadoChanged();
    partial void OnActivoSNChanging(bool value);
    partial void OnActivoSNChanged();
    #endregion
		
		public Plato()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PlatoID", AutoSync=AutoSync.OnInsert, DbType="SmallInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public short PlatoID
		{
			get
			{
				return this._PlatoID;
			}
			set
			{
				if ((this._PlatoID != value))
				{
					this.OnPlatoIDChanging(value);
					this.SendPropertyChanging();
					this._PlatoID = value;
					this.SendPropertyChanged("PlatoID");
					this.OnPlatoIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nombre", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Nombre
		{
			get
			{
				return this._Nombre;
			}
			set
			{
				if ((this._Nombre != value))
				{
					this.OnNombreChanging(value);
					this.SendPropertyChanging();
					this._Nombre = value;
					this.SendPropertyChanged("Nombre");
					this.OnNombreChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DescPlato", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string DescPlato
		{
			get
			{
				return this._DescPlato;
			}
			set
			{
				if ((this._DescPlato != value))
				{
					this.OnDescPlatoChanging(value);
					this.SendPropertyChanging();
					this._DescPlato = value;
					this.SendPropertyChanged("DescPlato");
					this.OnDescPlatoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Precio", DbType="Money NOT NULL")]
		public decimal Precio
		{
			get
			{
				return this._Precio;
			}
			set
			{
				if ((this._Precio != value))
				{
					this.OnPrecioChanging(value);
					this.SendPropertyChanging();
					this._Precio = value;
					this.SendPropertyChanged("Precio");
					this.OnPrecioChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Foto", DbType="VarBinary(MAX) NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary Foto
		{
			get
			{
				return this._Foto;
			}
			set
			{
				if ((this._Foto != value))
				{
					this.OnFotoChanging(value);
					this.SendPropertyChanging();
					this._Foto = value;
					this.SendPropertyChanged("Foto");
					this.OnFotoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Estado", DbType="Bit NOT NULL")]
		public bool Estado
		{
			get
			{
				return this._Estado;
			}
			set
			{
				if ((this._Estado != value))
				{
					this.OnEstadoChanging(value);
					this.SendPropertyChanging();
					this._Estado = value;
					this.SendPropertyChanged("Estado");
					this.OnEstadoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivoSN", DbType="Bit NOT NULL")]
		public bool ActivoSN
		{
			get
			{
				return this._ActivoSN;
			}
			set
			{
				if ((this._ActivoSN != value))
				{
					this.OnActivoSNChanging(value);
					this.SendPropertyChanging();
					this._ActivoSN = value;
					this.SendPropertyChanged("ActivoSN");
					this.OnActivoSNChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
