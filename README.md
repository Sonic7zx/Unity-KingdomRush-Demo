# Unity-KingdomRush-Demo
## 🎥 项目演示视频
[点击此处观看演示视频](https://www.bilibili.com/video/BV1qHTs6SEcQ)

## 🎮 游戏简介
一款基于 Unity 2022.3 开发的 2D 塔防游戏 Demo。灵感来源于《王国保卫战》，玩家通过建造防御塔抵御敌人进攻，保护终点水晶。项目从零开始独立开发，包含完整的建造、战斗、波次和经济系统。

## 🖥️ 运行环境
- Unity 2022.3 LTS 及以上
- 支持 Windows 平台

## 🎯 核心功能
### 已完成功能
- Tilemap 地图搭建 + Waypoint 路径点系统
- 敌人沿路径移动（支持随机偏移，视觉更自然）
- 多种敌人类型（哥布林、重甲兵、Barkie）继承自 Enemy 基类
- 敌人四方向移动动画（Blend Tree 混合）
- 敌人到达终点扣减水晶血量（不同敌人伤害不同）
- 塔位建造系统（悬停放大变色 → 点击弹出菜单 → 选择建造）
- 像素帧建造动画（Animator + Animation Event）
- 金币经济系统（初始金币、击杀得金币、建造/升级扣金币）
- 箭塔攻击系统（索敌 → 追踪子弹 → 伤害）
- 子弹对象池（UnityEngine.Pool 实现，减少 GC）
- 塔基类设计（TowerBase），支持后续扩展多种塔类型
- ScriptableObject 数据驱动波次系统（可配置多波敌人组合）
- 开始菜单 / 关卡选择（分页滚动 + 页码指示器）/ 设置面板（BGM/音效调节）
- 关卡胜利 / 失败 UI（3秒后自动返回选关）
- BGM 与音效系统（设置面板实时调节）

## 🛠️ 技术亮点
- **架构设计**：使用 `ScriptableObject` 配置关卡与波次，实现数据与逻辑分离；塔基类（TowerBase）支持多态扩展
- **对象池**：基于 `UnityEngine.Pool` 实现子弹复用，避免高频 Instantiate/Destroy 带来的性能开销
- **动画系统**：使用 Blend Tree 实现敌人四方向移动动画；Animation Event 精确控制建造动画结束时机
- **交互反馈**：塔位悬停放大变色、建造菜单动态跟随、波次出怪 Icon 呼吸效果
- **战斗系统**：塔优先攻击离终点最近的敌人（`GetRemainingDistance` 方法）；箭矢根据方向自动旋转对准目标
- **版本控制**：规范的 Git 提交记录，每个功能点独立 Commit，便于追溯

## 📦 如何运行
1. 克隆本项目到本地
2. 用 Unity 2022.3 LTS 打开项目文件夹
3. 打开场景 `Assets/Scenes/StartMenu.unity`（或 `Main.unity`）
4. 点击 Play 运行游戏
