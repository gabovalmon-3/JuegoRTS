# Proyecto_ProgramacionConPatrones

Descripción general del proyecto
El repositorio contiene un proyecto de Unity orientado a un juego de estrategia en tiempo real (RTS). Está organizado como una típica estructura de Unity (Assets, Packages, ProjectSettings) y emplea Universal Render Pipeline (URP). El objetivo del juego es construir y defender una base, recolectar recursos y crear unidades militares para combatir oleadas de enemigos controlados por IA.

Ambiente y mecánicas básicas
Mapa y obstáculos
BuilderFiguras, BuilderCubos, BuilderCilindro, ColisionObConfig, ColisionObInter, FigurasInter, DirectorMapa: implementan un patrón Builder para generar aleatoriamente cubos y cilindros que funcionan como obstáculos con colisiones y obstáculos de NavMesh.

Recursos
DirectorRecursos, BuilderRecursos, GruposRecursos, TipoRecurso: distribuyen grupos de recursos (Comida, Metal) por el mapa, dándoles valor y tipo.

Cámara RTS
RTSCameraController: permite mover la cámara mediante teclado, bordes de pantalla o arrastre, con opción de seguir a un objetivo.

Interfaz y utilidades
FaceCamera: hace que un objeto mire siempre a la cámara.

HealthTracker: barra de vida con colores según el porcentaje.

Rotador, SimplePatrol: scripts simples de rotación o patrulla lineal.

Player: ejemplo de slider de vida que disminuye al presionar espacio.

Construcciones y economía
Building (clase base), BuildingFactory (fábrica abstracta).

Fábricas concretas: BaseFactory, RecolectorFactory, MilitarFactory.

Gestión y creación de edificios
BuildingManager: cambia la fábrica según teclas (1–3) y coloca edificios donde se haga clic si se dispone de oro.

BasePrincipal: base principal con puntos de vida; si cae, es derrota.

RecolectorRecursos: genera oro periódicamente.

EdificioMilitar: entrena unidades a cambio de oro.

GameManager: singleton que maneja el oro, condiciones de victoria y derrota.

Unidades del jugador
Clases y estados
UnidadMilitar: unidad aliada que puede moverse, recibir daño, cambiar de estado y registrarse en una lista global.

Interfaces: IUnidad, IUnidadEjecutable, IEstadoUnidadJugador, IComando.

Estados de la unidad:

EstadoIdle: sin acción.

EstadoAtacarAuto: busca enemigos cercanos y les inflige daño automático.

Movimiento y ataque
UnitMovement: usa NavMeshAgent para moverse al clic derecho.

AttackController: almacena objetivo y cambia materiales según estado (idle, follow, attack).

UnitIdleState, UnitFollowState, UnitAttackState: controlan las animaciones y lógica de ataque a través de una máquina de estados (Animator).

Selección y control de unidades
UnitSelectionManager: gestiona selección individual y múltiple de unidades, movimiento al lugar clicado y asignación de objetivos de ataque.

UnitSelectionBox: dibuja la caja de selección al arrastrar el ratón.

SeleccionMultiple y ControladorUnidades: alternativas manuales para selección múltiple y emisión de órdenes.

ComandoMover: patrón Command que encapsula la orden de mover una unidad.

GrupoUnidades: agrupado para mover varias unidades como un solo conjunto.

Enemigos y oleadas
OleadasManager: genera oleadas incrementales de enemigos.

EnemigoIA: enemigo con estados (EstadoPatrullar, EstadoAtacar), vida y estrategias de combate (EstrategiaMelee, EstrategiaRanged).

Interfaces y estados
IEstadoUnidadIA, IEstrategiaCombate.

EstadoPatrullar: recorre puntos de patrulla.

EstadoAtacar: persigue unidades o la base.

Otros componentes de IA
Enemy y UnidadMilitar implementan IDamageable.

EnemySpawner (en carpeta AI): spawner configurable continuo o por oleadas.

EnemyAIController (en AI): IA más avanzada con FSM (Idle/Chase/Attack) que prioriza objetivos (unidades, centro urbano, otros edificios).

Health, Targetable, Team (en AI): componentes reutilizables para manejar vida, equipo y selección de objetivos.

Interfaz de recursos
UIRecursosTMP: actualiza textos de oro, unidades, enemigos y número de oleada en pantalla.

Otros scripts generales
Unit, Enemy: implementaciones simples de unidades/damageables.

UnidadesSpawner: crea unidades desde un prototipo.

GrupoUnidades: maneja listas de unidades para ejecutar órdenes colectivas.

Scripts de muestra del URP
En Assets/Samples/Universal Render Pipeline/17.1.0/URP Package Samples, hay código proporcionado por Unity para demostrar características del URP (lentes flare, copia de profundidad, distorsión, controladores de cámara, etc.). Estos scripts ilustran técnicas gráficas y no están directamente ligados a la lógica del juego.

Personajes y componentes principales
Jugador
Controla la cámara, construye edificios y selecciona unidades.

Unidades Aliadas (UnidadMilitar)
Soldados que patrullan, se mueven y atacan automáticamente al enemigo.

Edificios

BasePrincipal: centro que debe protegerse.

RecolectorRecursos: genera oro.

EdificioMilitar: entrena nuevas unidades.

Enemigos (EnemigoIA)
Atacan en oleadas, persiguen unidades y edificios del jugador.

Recursos
Grupos de Comida y Metal distribuidos en el mapa; representados por objetos con valores numéricos.

Funcionamiento del juego
Generación del mundo: al iniciar, se crean obstáculos aleatorios (cubos/cilindros) y grupos de recursos según el ancho y largo del mapa.

Economía: el jugador comienza con oro; los recolectores generan más oro. El oro se gasta para construir y entrenar.

Construcción: mediante teclas numéricas se seleccionan distintos edificios para colocar en el terreno.

Unidades: las unidades militares entrenadas pueden seleccionarse (individual o múltiple) y moverse mediante clic derecho.

Combate: las unidades atacan automáticamente cuando detectan enemigos cercanos. Enemigos patrullan o atacan la base y las unidades aliadas.

Oleadas: OleadasManager lanza olas de enemigos cada cierto tiempo; al superar una cantidad de oleadas, se declara la victoria.

Final del juego: perder la base resulta en derrota; eliminar enemigos y resistir oleadas lleva a la victoria.

Conclusión
El proyecto es un prototipo educativo de un RTS en Unity que combina patrones de diseño (Builder, Command, Strategy), control de cámara, selección múltiple de unidades, economía básica y un sistema de IA/oleadas. Cada script cumple un rol específico dentro del flujo del juego: generación del escenario, administración de recursos, creación y control de unidades, ataques, IA de enemigos y manejo de la interfaz.
