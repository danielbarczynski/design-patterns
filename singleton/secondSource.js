import FancyLogger from "./FancyLogger.js";

const logger = new FancyLogger();

export default function log() {
    logger.log('second source file')
    logger.logCount();
}