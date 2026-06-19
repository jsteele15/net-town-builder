
export const Map = {
    tileSize: 32,
    ctx: null,
    tileMap: null,
    
    init(canvasId) {
        const canvas = document.getElementById(canvasId);
        this.ctx = canvas.getContext("2d");

        this.tileMap = new Image();
        this.tileMap.src = '../assets/map_assets/maptiles.png';
    },
    setUpMap(size){
        // The point of this function is to go through and place tiles on the screen based on the map size
        for(let x = 0; x < size; x++){
            for(let y = 0; y < size; y++){
                // So I dont forget
                // source x, source y, width x, height y
                // destination x, destination y, destination width, destination height
                this.ctx.drawImage(this.tileMap, x * this.tileSize, y * this.tileSize, this.tileSize, this.tileSize, x * this.tileSize, y * this.tileSize, this.tileSize, this.tileSize);
                console.log(x, y)
            }; 
        };
}
};
