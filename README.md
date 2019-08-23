# Hassium Engine

A C# game engine built on top of MonoGame, which was developed myself for my uni games engineering team project, to support the creation 
of 2D/2D isometric games using OOP SOLID principles.

The design of the engine is influenced by an ECS (entity-component-system) game engine architecture to aid with SOLID principles, 
but is not an actual ECS engine.

The engine is composed of five core systems: Collision, Input, Load, Render, Update.

It is also composed of two component managers: Entity, Scene.

An entity inherits the abstract entity class and can implement multiple interfaces based on the behaviours it requires: 
ICollidable, IEventListener\<T>, ILoadable, IRenderOrderChangeable, IRenderable, IUpdatable.

The engine provides higher level features by building on top of MonoGame's lower level framework components such as: scene management, 
the ability to run multiple scenes which can all be in different states, friendlier to use input listeners and implementations of 
collision detection.

The engine isn't necessarily production ready, but it does work as we were able to build our 2D isometric game on it without any issues.

## License
Copyright &copy;2019 Hassie.

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
