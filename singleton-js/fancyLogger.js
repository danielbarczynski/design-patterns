// without Singleton Pattern
// export default 
class FancyLogger {
    constructor() {
        if (FancyLogger.instance == null){
            this.logs = [];
            FancyLogger.instance = this;
        }

        return FancyLogger.instance;
    }

    log(message) {
        this.logs.push(message);
        console.log(`message: ${message}`);
    }

    logCount() {
        console.log(`${this.logs.length} logs`);
    }
}

// with Singleton Pattern 
const logger = new FancyLogger();
export default logger