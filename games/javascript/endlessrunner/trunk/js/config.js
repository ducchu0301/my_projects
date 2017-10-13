var config = {
    system: {
        width: 1920,
        height: 1024,
        fps: 60,
        interval: 1000,
        limitFps: 3
    },
    linkXML: "data.xml",
    canvasSize: {
        width: document.getElementById("myCanvas").width,
        height: document.getElementById("myCanvas").height
    },
    sources: ["skyMoon", "city1", "city2", "trees", "bush", "platform", "tires", "oneway", "coin", "player"],
    speeds: [0, -3, -6, -9, -11, -12, -12, -12, -12, 0],
    jump: 600,
    dieBounce: 30,
    scale: {
        scaleWidth: 1,
        scaleHeight: 1
    }
};
config.scale.scaleWidth = config.canvasSize.width / config.system.width;
config.scale.scaleHeight = config.canvasSize.height / config.system.height;
config.system.interval = 1000 / config.system.fps;