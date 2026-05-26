### \# Sistema de Nómina

# 

###### Aplicación de consola desarrollada en C# con .NET 8 para la gestión de pagos semanales de empleados.

# 

### \## Características

# 

###### \- Gestión completa de empleados (agregar, actualizar, eliminar, consultar)

###### \- Soporte para 4 tipos de empleados: asalariado, por horas, por comisión y asalariado por comisión

###### \- Cálculo automático de pago semanal según el tipo de contrato

###### \- Reporte semanal con totales por tipo de empleado

###### \- Dos modos de almacenamiento: SQL Server y en memoria

# 

### \## Tipos de Empleado y Cálculo de Pago

# 

###### | Tipo | Fórmula |

###### |------|---------|

###### | Asalariado | Salario semanal fijo |

###### | Por Horas | Horas ≤ 40: sueldo × horas / Horas > 40: (sueldo × 40) + (sueldo × 1.5 × horas extra) |

###### | Por Comisión | Ventas brutas × tarifa de comisión |

###### | Asalariado por Comisión | (Ventas × tarifa) + salario base + (salario base × 10%) |

# 

### \## Tecnologías

# 

###### \- .NET 8

###### \- C#

###### \- Entity Framework Core 8

###### \- SQL Server

###### \- Principios SOLID, SoC, DRY, KISS, YAGNI

# 

### \## Estructura del Proyecto



###### SistemaNomina/

###### ├── SistemaNomina.Domain/       # Entidades e interfaces

###### ├── SistemaNomina.Data/         # Acceso a datos (EF Core + en memoria)

###### ├── SistemaNomina.Services/     # Lógica de negocio

###### └── SistemaNomina.ConsoleApp/   # Interfaz de consola



### \## Configuración



###### 1\. Clona el repositorio

###### 2\. Copia `appsettings.example.json` como `appsettings.json`

###### 3\. Actualiza la cadena de conexión en `appsettings.json`

###### 4\. Ejecuta el proyecto — EF Core creará la base de datos automáticamente

###### 

###### \## Modo en Memoria

###### 

###### Para usar el repositorio en memoria en lugar de SQL Server,

###### cambia esta línea en `Program.cs`:

###### 

###### ```csharp

###### // SQL Server

###### var repository = new EmpleadoRepository(context);

###### 

###### // En memoria

###### var repository = new EmpleadoRepositoryMemoria();

###### ```



