export default class FancyLogger {
    constructor() {
        this.logs = [];
    }

    log(message) {
        this.logs.push(message);
        console.log(`FANCY: ${message}`);
    }

    logCount() {
        console.log(`${this.logs.length} logs`);
    }
}

// const fancyLogger = new FancyLogger();
// fancyLogger.log('1 file');
// fancyLogger.logCount();